import React, { Component } from 'react'
import { Link } from "react-router-dom"
import { AppBar, Toolbar, Typography, Button, withStyles } from '@material-ui/core'

import useStyles from '../Styles/makeStyles.js'

class Header extends Component {
    render() {
        const { classes } = this.props;
        return (
            <AppBar position="static" style={{ background: '#263238' }}>
                <Toolbar color="#aaa">
                    <Typography variant="h6" className={classes.title}>
                        <Link to="/Blog" className={classes.link}>
                            NewsPortal
                        </Link>
                    </Typography>
                    <Link to="/Authorization" className={classes.link}>
                        <Button variant="outlined" style={{ borderColor: '#FFF', color: '#FFF' }}>
                            Войти
                        </Button>
                    </Link>
                </Toolbar>
            </AppBar>
        )
    }
}

export default withStyles(useStyles)(Header)