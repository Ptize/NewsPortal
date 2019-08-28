
import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import {
    Grid,
    Typography,
    withStyles,
    List,
    ListItem,
    ListItemText,
    Button
} from '@material-ui/core'
import { Form, Field } from 'react-final-form'

import { TextField, useStyles } from './Styles'
import UserContext from './UserContext.js'

class Dashboard extends Component {
    static contextType = UserContext
    constructor() {
        super()
        this.state = {
            expandMore: false,
            errorInfo: ''
        }
    }

    render() {
        const { classes } = this.props

        const onSubmit = async values => {
            values["email"] = this.context.currentUser
            fetch('/api/User/changePassword', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(values)
            })
                .then(res => {
                    console.log(JSON.stringify(values))
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
                        this.setState({ errorInfo: 'Неправильно указан старый пароль' })
                    else {
                        console.log('ПАРОЛЬ УСПЕШНО ИЗМЕНЕН')
                        toggleSettings()
                    }
                })
                .catch(err => {
                    console.log(err)
                })
        }

        const required = value => (value ? undefined : "Заполните это поле")

        const ExpandSettings = () => {
            return (
                <UserContext.Consumer>
                    {({ currentUser }) => (
                        <React.Fragment>
                            <Typography color="secondary">{this.state.errorInfo}</Typography>
                            <Form
                                onSubmit={onSubmit}
                                render={({ handleSubmit, form, submitting, pristine, values }) => (
                                    <form onSubmit={handleSubmit}
                                        initialvalues={{ email: currentUser }}>
                                        <div className={classes.fields}>
                                            <Field
                                                name="oldPassword"
                                                component={TextField}
                                                validate={required}
                                                type="password"
                                                label="Старый пароль"
                                            />
                                        </div>
                                        <div className={classes.fields}>
                                            <Field
                                                name="newPassword"
                                                component={TextField}
                                                validate={required}
                                                type="password"
                                                label="Новый пароль"
                                            />
                                        </div>
                                        <div className={classes.button}>
                                            <Button variant="outlined" color="secondary" type="submit" disabled={submitting || pristine}>
                                                Подтвердить
                                    </Button>
                                        </div>
                                    </form>
                                )
                                }
                            />
                        </React.Fragment>
                    )}
                </UserContext.Consumer>
            )
        }
        const toggleSettings = () => {
            this.setState({
                expandMore: !this.state.expandMore,
                errorInfo: ''
            })
        }

        return (
            <UserContext.Consumer>
                {({ currentUser }) => (
                    <Grid className={classes.dashboard}>
                        <Typography variant="h4" className={classes.dashTitle}>Личный кабинет</Typography>
                        <List>
                            <ListItem>
                                <Link to="/Blog" style={{ textDecoration: 'none' }}>
                                    <ListItemText
                                        primary="Вернуться на главную страницу"
                                    />
                                </Link>
                            </ListItem>
                            <ListItem>
                                <Link to="/NewsManager" style={{ textDecoration: 'none' }}>
                                    <ListItemText
                                        primary="Перейти к странице управления новостями"
                                    />
                                </Link>
                            </ListItem>
                        </List>
                        <Typography variant="h5">Ваши учетные данные </Typography>
                        <Typography className={classes.dashTitle}>E-mail: {currentUser}</Typography>
                        <Button color="primary" onClick={toggleSettings} className={classes.dashTitle}>
                            <Typography>Изменить пароль</Typography>
                        </Button>
                        {this.state.expandMore ? <ExpandSettings /> : null}
                    </Grid>
                )}
            </UserContext.Consumer>
        )
    }
}

export default withStyles(useStyles)(Dashboard)