import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { AppBar, Toolbar, Typography, Button, withStyles } from '@material-ui/core'

import useStyles from '../Styles/makeStyles.js'
import UserContext from '../UserContext'

class Header extends Component {
    static contextType = UserContext
    constructor(props) {
        super(props)
    }

    render() {
        const { classes } = this.props

        const handleLogOut = () => {
            fetch('/api/User/logout', { method: 'POST' })
                .then(res => {
                    if (!res.ok) {
                        throw new Error(res.status)
                    }
                    else
                        return res.text()
                })
                .then(res => {
                    console.log('res = ' + res)
                    this.context.updateValue('')
                    localStorage.removeItem('currentUser')
                })
                .catch(err => {
                    console.log(err)
                })
        }
        return (
            <UserContext.Consumer>
                {({ currentUser }) => (
                    <AppBar position="static" style={{ background: '#263238' }}>
                        <Toolbar color="#aaa">
                            <Typography variant="h6" className={classes.title}>
                                <Link to="/Blog" className={classes.link}>
                                    NewsPortal
                                </Link>
                            </Typography>
                            {/* Render login or logout button */}
                            {currentUser == '' ?
                                <Link to="/Authorization" className={classes.link}>
                                    <Button variant="outlined" style={{ borderColor: '#FFF', color: '#FFF' }}>
                                        Войти
                                    </Button>
                                </Link>
                                :
                                <Link to="/Blog" className={classes.link}>
                                    <Button variant="outlined" style={{ borderColor: '#FFF', color: '#FFF' }} onClick={handleLogOut}>
                                        Выход
                                    </Button>
                                </Link>
                            }
                        </Toolbar>
                    </AppBar>
                )}
            </UserContext.Consumer>
        )
    }
}

export default withStyles(useStyles)(Header)