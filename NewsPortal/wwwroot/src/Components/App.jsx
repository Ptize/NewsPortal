import React, { Component } from 'react'
import { BrowserRouter as Router, Switch, Route } from "react-router-dom"
import { Container, withStyles } from '@material-ui/core'

import { useStyles } from './Styles'
import { Header, Footer } from './Layouts'
import Blog from './Blog.jsx'
import NewsDetail from './NewsDetail.jsx'
import Registration from './Registration.jsx'
import Authorization from './Authorization.jsx'
import NewsManager from './NewsManager.jsx'

class App extends Component {
  render() {
    const { classes } = this.props // useStyles
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
              <Route path="/Newsmanager" component={NewsManager} />
            </Switch>
          </Container>
          <Footer />
        </React.Fragment>
      </Router>
    )
  }
}

export default withStyles(useStyles)(App)