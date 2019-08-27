import React, { Component } from 'react'
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import { Container, withStyles } from '@material-ui/core'

import { useStyles } from './Styles'
import { Header, Footer } from './Layouts'
import Blog from './Blog.jsx'
import NewsDetail from './NewsDetail.jsx'
import Registration from './Registration.jsx'
import Authorization from './Authorization.jsx'
import NewsManager from './NewsManager.jsx'
import UserContext from './UserContext'
import { ProtectedRoute } from './ProtectedRoute'

class App extends Component {
  constructor(props) {
    super(props)
    this.updateValue = (val) => {
      this.setState({
        currentUser: val
      })
    }

    this.state = {
      currentUser: '',
      updateValue: this.updateValue,
    }
  }

  render() {
    return (
      <UserContext.Provider value={this.state}>
        <Router>
          <React.Fragment>
            <Container maxWidth="lg">
              <Header />
              <Switch>
                <Route exact path="/" component={Blog} />
                <Route exact path="/Blog" component={Blog} />
                <Route path="/Registration" component={Registration} />
                <Route path="/Authorization" component={Authorization} />
                <ProtectedRoute path="/Blog/News/:newsId" component={NewsDetail} />
                <ProtectedRoute path="/Newsmanager" component={NewsManager} />
              </Switch>
            </Container>
            <Footer />
          </React.Fragment>
        </Router>
      </UserContext.Provider>
    )
  }
}

export default withStyles(useStyles)(App)