import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Container from '@material-ui/core/Container';
import { withStyles } from '@material-ui/core/styles';

import useStyles from './component/makeStyles.js';
import Header from './component/Header.jsx';
import Footer from './component/Footer.jsx';
import Blog from './component/Blog.jsx';
import NewsDetail from './component/NewsDetail.jsx';
import Registration from './component/Registration.jsx';
import Authorization from './component/Authorization.jsx';

class App extends Component {
  render() {
    const { classes } = this.props;
    return (
      <Router>
        <React.Fragment>
          <Container maxWidth="lg">
            <Header />
            <Switch>
              <Route exact path="/" component={Blog} />
              <Route exact path="/Blog" component={Blog} />
              <Route path="/Registration" component={Registration} />
              <Route path="/Authorization" component={Authorization} />
              <Route path="/Blog/News/:newsId" component={NewsDetail} />
            </Switch>
          </Container>
          <Footer />
        </React.Fragment>
      </Router>
    );
  }
}

export default withStyles(useStyles)(App);