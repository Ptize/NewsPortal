import React, { Component } from 'react'
import { Link } from "react-router-dom"
import { Form, Field } from "react-final-form"
import { Box, Typography, Button, withStyles } from '@material-ui/core'

import { TextField, Radio, useStyles } from './Styles'

class Authorization extends Component {
    render() {
        const { classes } = this.props

        const sleep = ms => new Promise(resolve => setTimeout(resolve, ms))

        const onSubmit = async values => {
            await sleep(300)
            window.alert(JSON.stringify(values, 0, 2))
        }

        const required = value => (value ? undefined : "Заполните это поле");

        return (
            <Box height="85%" className={classes.forms}>
                <Typography variant="h5">Вход</Typography>
                <Typography className={classes.fields}>
                    Нет учетной записи? <Link to="Registration">Зарегистрируйтесь</Link>
                </Typography>
                <Form
                    onSubmit={onSubmit}
                    render={({ handleSubmit, form, submitting, pristine, values }) => (
                        <form onSubmit={handleSubmit}>
                            <div className={classes.fields}>
                                <Field
                                    name="nickname"
                                    component={TextField}
                                    validate={required}
                                    type="text"
                                    label="Логин"
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