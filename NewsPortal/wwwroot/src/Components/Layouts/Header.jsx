import React, { Component } from 'react'
import { Link } from "react-router-dom"
import { AppBar, Toolbar, Typography, Button, withStyles } from '@material-ui/core'
import dark from '@material-ui/core/colors'

import useStyles from '../Styles/makeStyles.js'

class Header extends Component {
    render() {
        const { classes } = this.props;
        return (
            <AppBar position="static" style={{ background: dark }}>
                <Toolbar color="#aaa">
                    <Typography variant="h6" className={classes.title}>
                        <Link to="/Blog" className={classes.link}>
                            NewsPortal
                        </Link>
                    </Typography>
                    <Button variant="outlined" style={{ borderColor: '#FFF' }}>
                        <Link to="/Authorization" className={classes.link}>
                            Войти
                        </Link>
                    </Button>
                </Toolbar>
            </AppBar>
            //     <Toolbar className={classes.toolbar}>
            //         <Typography
            //             component="h2"
            //             variant="h4"
            //             color="inherit"
            //             align="center"
            //             noWrap
            //             className={classes.toolbarTitle}
            //         >
            //             NewsPortal
            // </Typography>
            //         <Link to="/Authorization">
            //             <Button variant="outlined" size="small">
            //                 Войти
            //             </Button>
            //         </Link>
            //     </Toolbar>
        )
    }
}

export default withStyles(useStyles)(Header)