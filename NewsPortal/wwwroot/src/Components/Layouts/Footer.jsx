import React, { Component } from 'react'
import { Container, Typography } from '@material-ui/core'
import { withStyles } from '@material-ui/core/styles'

import useStyles from '../Styles/makeStyles.js'

class Footer extends Component {
    render() {
        const { classes } = this.props;
        return (
            <footer className={classes.footer}>
                <Container maxWidth="lg">
                    <Typography variant="subtitle1" align="center" color="textSecondary" component="p">
                        Developed by team Delta
                    </Typography>
                </Container>
            </footer>
        )
    }
}

export default withStyles(useStyles)(Footer)