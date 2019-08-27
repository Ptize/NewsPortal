import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { Form, Field } from 'react-final-form'
import { Box, Typography, Button, withStyles } from '@material-ui/core'

import { TextField, Checkbox, useStyles } from './Styles'
import UserContext from './UserContext'

class Authorization extends Component {
    static contextType = UserContext
    constructor() {
        super()
        this.state = {
            errorInfo: ''
        }
    }

    render() {
        const { classes } = this.props

        const onSubmit = async values => {
            fetch('/api/User/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(values)
            })
                .then(res => {
                    if (!res.ok) {
                        this.setState({ errorInfo: 'Что-то случилось. Повторите попытку позже' })
                        throw new Error(res.status)
                    }
                    else
                        return res.text()
                })
                .then(res => {
                    console.log(res)
                    if (res != 0)
                        this.setState({ errorInfo: 'Неправильно введена почта или пароль' })
                    else {
                        this.context.updateValue(values.email)
                        localStorage.setItem('currentUser', values.email)
                        this.props.history.push('/Blog')
                    }
                })
                .catch(err => {
                    console.log(err)
                })
        }

        const required = value => (value ? undefined : "Заполните это поле")

        return (
            <Box height="85%" className={classes.forms}>
                <Typography variant="h5">Вход</Typography>
                <Typography className={classes.fields}>
                    Нет учетной записи? <Link to="Registration">Зарегистрируйтесь</Link>
                </Typography>
                <Typography className={classes.fields} color="secondary">{this.state.errorInfo}</Typography>
                <Form
                    onSubmit={onSubmit}
                    render={({ handleSubmit, form, submitting, pristine, values }) => (
                        <form onSubmit={handleSubmit}
                            initialvalues={{ rememberMe: true }}>
                            <div className={classes.fields}>
                                <Field
                                    name="email"
                                    component={TextField}
                                    validate={required}
                                    type="email"
                                    label="E-mail"
                                />
                            </div>
                            <div className={classes.fields}>
                                <Field
                                    name="password"
                                    component={TextField}
                                    validate={required}
                                    type="password"
                                    label="Пароль"
                                />
                            </div>
                            {/* <div className={classes.fields}>
                                <Field
                                    name="rememberMe"
                                    component={Checkbox}
                                    type="checkbox"
                                />{' '}
                                Запомнить меня
                            </div> */}
                            <div className={classes.button}>
                                <Button variant="outlined" color="primary" type="submit" disabled={submitting || pristine}>
                                    Войти
                                </Button>
                            </div>
                        </form>
                    )}
                />
            </Box>
        )
    }
}

export default withStyles(useStyles)(Authorization)