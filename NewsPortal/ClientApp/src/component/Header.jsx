import React, { Component } from 'react'
import { Link } from "react-router-dom";
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import useStyles from './makeStyles.js';

class Header extends Component {
    render() {
        const { classes } = this.props;
        return (
            <Toolbar className={classes.toolbar}>
                <Typography
                    component="h2"
                    variant="h4"
                    color="inherit"
                    align="center"
                    noWrap
                    className={classes.toolbarTitle}
                >
                    NewsPortal
        </Typography>
                <IconButton>
                    <SearchIcon />
                </IconButton>
                <Link to="/Authorization">
                    <Button variant="outlined" size="small">
                        Войти
                    </Button>
                </Link>
            </Toolbar>
        )
    }
}

export default withStyles(useStyles)(Header);