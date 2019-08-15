import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import Paper from '@material-ui/core/Paper';
import { withStyles } from '@material-ui/core/styles';
import useStyles from './component/makeStyles.js';
import Blog from './component/Blog.jsx'
import NewsDetail from './component/NewsDetail.jsx'

class App extends Component {
  render() {
    const { classes } = this.props;
    return (
      <React.Fragment>
        <Container maxWidth="lg">
          {/* Header */}
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
            <Button variant="outlined" size="small">
              Войти
          </Button>
          </Toolbar>
          {/*End header */}
          <Router>
            <Switch>
              <Route path="/" exact component={Blog} />
              <Route path="/Blog" exact component={Blog} />
              <Route path="/Blog/News/:newsId" component={NewsDetail} />
            </Switch>
          </Router>
        </Container>
        {/* Footer */}
        <footer className={classes.footer}>
          <Container maxWidth="lg">
            <Typography variant="subtitle1" align="center" color="textSecondary" component="p">
              Developed by team Delta
          </Typography>
          </Container>
        </footer>
        {/* End footer */}
      </React.Fragment>
    );
  }
}

export default withStyles(useStyles)(App);