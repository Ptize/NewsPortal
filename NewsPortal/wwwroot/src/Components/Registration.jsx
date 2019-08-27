import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { Form, Field } from 'react-final-form'
import { Box, Typography, Button, FormLabel, withStyles } from '@material-ui/core'

import { TextField, Radio, useStyles } from './Styles'

class Registration extends Component {
    constructor() {
        super()
        this.state = {
            errorInfo: ''
        }
    }

    render() {
        const { classes } = this.props

        const handleSubmit = async values => {
            if (values.password !== values.passwordConfirm) {
                this.setState({ errorInfo: 'Пароли должны совпадать' })
                return
            }
            fetch('/api/User', {
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
                        this.setState({ errorInfo: 'Такой пользователь уже зарегистрирован, либо не соблюдены критерии для пароля' })
                    else {
                        window.alert('Регистрация прошла успешно!')
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
                <Typography variant="h5">Регистрация</Typography>
                <Typography className={classes.fields}>Уже есть учетная запись? <Link to="Authorization">Войдите</Link> </Typography>
                <Typography className={classes.fields} color="textSecondary">Пароль должен иметь буквы верхнего и нижнего регистров,<br />
                    не короче 8 символов, цифры, не 3 подряд, спец. символы, не менее 1</Typography>
                <Typography className={classes.fields} color="secondary">{this.state.errorInfo}</Typography>
                <Form
                    onSubmit={handleSubmit}
                    render={({ handleSubmit, form, submitting, pristine, values }) => (
                        <form onSubmit={handleSubmit}>
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
                            <div className={classes.fields}>
                                <Field
                                    name="passwordConfirm"
                                    component={TextField}
                                    validate={required}
                                    type="password"
                                    label="Подтверждение пароля"
                                />
                            </div>
                            <div className={classes.buttons}>
                                <div className={classes.button}>
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        type="submit"
                                        disabled={submitting || pristine}>
                                        Подтвердить
                                    </Button>
                                </div>
                                <div className={classes.button}>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        type="button"
                                        onClick={form.reset}
                                        disabled={submitting || pristine}>
                                        Очистить поля
                                    </Button>
                                </div>
                            </div>
                        </form>
                    )}
                />
            </Box>
        )
    }
}

export default withStyles(useStyles)(Registration)