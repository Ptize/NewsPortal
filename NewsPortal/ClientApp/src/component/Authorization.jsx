import React, { Component } from 'react'
import { Link } from "react-router-dom";
import { Form, Field } from "react-final-form";
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import TextField from './TextField';
import Radio from './Radio';

const sleep = ms => new Promise(resolve => setTimeout(resolve, ms))

const onSubmit = async values => {
    await sleep(300)
    window.alert(JSON.stringify(values, 0, 2))
}

const required = value => (value ? undefined : "Заполните это поле");

const Authorization = () => (
    <div>
        <Typography variant="h5">Вход</Typography>
        <Typography>Нет учетной записи? <Link to="Registration">Зарегистрируйтесь</Link></Typography>
        <Form
            onSubmit={onSubmit}
            initialValues={{ role: 'editor' }}
            render={({ handleSubmit, form, submitting, pristine, values }) => (
                <form onSubmit={handleSubmit}>
                    <div>
                        <Field
                            name="nickname"
                            component={TextField}
                            validate={required}
                            type="text"
                            label="Логин"
                        />
                    </div>
                    <div>
                        <Field
                            name="password"
                            component={TextField}
                            validate={required}
                            type="password"
                            label="Пароль"
                        />
                    </div>
                    <div className="buttons">
                        <Button variant="outlined" color="primary" type="submit" disabled={submitting || pristine}>
                            Войти
            </Button>
                    </div>
                </form>
            )}
        />
    </div>
)

export default Authorization;