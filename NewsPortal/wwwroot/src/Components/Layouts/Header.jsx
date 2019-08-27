import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import {
    AppBar,
    Toolbar,
    Typography,
    Button,
    withStyles
} from '@material-ui/core'
import ExpandableSettings from './ExpandableSettings.jsx'

import useStyles from '../Styles/makeStyles.js'
import UserContext from '../UserContext'

class Header extends Component {
    static contextType = UserContext
    constructor(props) {
        super(props)
        this.state = {
            open: false
        }
    }

    render() {
        const { classes } = this.props

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
                                <ExpandableSettings />
                            }
                        </Toolbar>
                    </AppBar>
                )}
            </UserContext.Consumer>
        )
    }
}

export default withStyles(useStyles)(Header)