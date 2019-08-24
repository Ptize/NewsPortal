import React, { Component } from 'react'
import { Link } from "react-router-dom"
import { Form, Field } from "react-final-form"
import { Box, Typography, Button, FormLabel, withStyles } from '@material-ui/core'

import { TextField, Radio, useStyles } from './Styles'

class Registration extends Component {
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
                <Typography variant="h5">Регистрация</Typography>
                <Typography className={classes.fields}>Уже есть учетная запись? <Link to="Authorization">Войдите</Link> </Typography>
                <Form
                    onSubmit={onSubmit}
                    initialValues={{ role: 'editor' }}
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
                                    name="lastName"
                                    component={TextField}
                                    validate={required}
                                    type="text"
                                    label="Фамилия"
                                />
                            </div>
                            <div className={classes.fields}>
                                <Field
                                    name="firstName"
                                    component={TextField}
                                    validate={required}
                                    type="text"
                                    label="Имя"
                                />
                            </div>
                            <div className={classes.fields}>
                                <Field
                                    name="middleName"
                                    component={TextField}
                                    type="text"
                                    label="Отчество"
                                />
                            </div>
                            <div className={classes.button}>
                                <FormLabel>Роль</FormLabel>
                                <div className={classes.fields}>
                                    <Field
                                        name="role"
                                        component={Radio}
                                        type="radio"
                                        value="editor"
                                    />{' '}
                                    Редактор
                                    </div>
                                <div>
                                    <Field
                                        name="role"
                                        component={Radio}
                                        type="radio"
                                        value="admin"
                                    />{' '}
                                    Администратор
                                </div>
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
                            <pre>{JSON.stringify(values, 0, 2)}</pre>
                        </form>
                    )}
                />
            </Box>
        )
    }
}

export default withStyles(useStyles)(Registration)