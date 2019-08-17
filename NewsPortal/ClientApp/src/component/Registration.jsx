import React, { Component } from 'react'
import { Link } from "react-router-dom";
import { Form, Field } from "react-final-form";
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import FormLabel from '@material-ui/core/FormLabel';
import TextField from './TextField';
import Radio from './Radio';

const sleep = ms => new Promise(resolve => setTimeout(resolve, ms))

const onSubmit = async values => {
    await sleep(300)
    window.alert(JSON.stringify(values, 0, 2))
}

const required = value => (value ? undefined : "Заполните это поле");

const Registration = () => (
    <div>
        <Typography variant="h5">Регистрация</Typography>
        <Typography>Уже есть учетная запись? <Link to="Authorization">Войдите</Link> </Typography>
        <Form
            onSubmit={onSubmit}
            initialValues={{ role: 'editor' }}
            render={({ handleSubmit, form, submitting, pristine, values }) => (
                <form onSubmit={handleSubmit}>
                    {/* <Field name="nickname" validate={required}>
                        {({ input, meta }) => (
                            <div className={meta.active ? 'active' : ''}>
                                <label>Логин</label>
                                <input {...input} type="text" placeholder="Логин" />
                                {meta.error && meta.touched && <span>{meta.error}</span>}
                            </div>
                        )}
                    </Field> */}
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
                            name="lastName"
                            component={TextField}
                            validate={required}
                            type="text"
                            label="Фамилия"
                        />
                    </div>
                    <div>
                        <Field
                            name="firstName"
                            component={TextField}
                            validate={required}
                            type="text"
                            label="Имя"
                        />
                    </div>
                    <div>
                        <Field
                            name="middleName"
                            component={TextField}
                            type="text"
                            label="Отчество"
                        />
                    </div>
                    <div>
                        <FormLabel>Роль</FormLabel>
                        <div>
                            <Field
                                name="role"
                                component={Radio}
                                type="radio"
                                value="editor"
                            />{' '}
                            Редактор
                            <Field
                                name="role"
                                component={Radio}
                                type="radio"
                                value="admin"
                            />{' '}
                            Администратор
                    </div>
                    </div>
                    <div className="buttons">
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            disabled={submitting || pristine}>
                            Подтвердить
                        </Button>
                        <Button
                            variant="contained"
                            color="secondary"
                            type="button"
                            onClick={form.reset}
                            disabled={submitting || pristine}>
                            Очистить поля
                        </Button>
                    </div>
                    <pre>{JSON.stringify(values, 0, 2)}</pre>
                </form>
            )}
        />
    </div>
)

export default Registration;