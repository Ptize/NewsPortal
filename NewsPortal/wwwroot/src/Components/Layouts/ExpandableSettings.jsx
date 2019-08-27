import React, { useContext } from 'react'
import { Link } from 'react-router-dom'
import {
    AppBar,
    Toolbar,
    Typography,
    IconButton,
    Menu,
    MenuItem,
    Switch,
    FormControlLabel,
    FormGroup
} from '@material-ui/core'
import { MenuIcon, AccountCircle } from '@material-ui/icons'

import UserContext from '../UserContext'

export default function ExpandableSettings() {
    const contextType = useContext(UserContext)
    const [anchorEl, setAnchorEl] = React.useState(null)
    const open = Boolean(anchorEl)

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
                handleClose()
                contextType.updateValue('')
                localStorage.removeItem('currentUser')
            })
            .catch(err => {
                console.log(err)
            })
    }

    function handleMenu(event) {
        setAnchorEl(event.currentTarget)
    }

    function handleClose() {
        setAnchorEl(null)
    }

    return (
        <React.Fragment>
            <IconButton
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleMenu}
                color="inherit"
            >
                <AccountCircle />
            </IconButton>
            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                }}
                open={open}
                onClose={handleClose}
            >
                <Link to="/Dashboard" style={{ textDecoration: 'none', color: '#000' }}>
                    <MenuItem onClick={handleClose}>Личный кабинет</MenuItem>
                </Link>
                <Link to="/Blog" style={{ textDecoration: 'none', color: '#000' }}>
                    <MenuItem onClick={handleLogOut}>Выход</MenuItem>
                </Link>
            </Menu>
        </React.Fragment>
    )
}