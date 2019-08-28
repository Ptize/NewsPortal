import React from 'react'
import { Route, Redirect } from 'react-router-dom'
import UserContext from './UserContext'

export const ProtectedRoute = ({ component: Component, ...rest }) => {
    return (
        <UserContext.Consumer>
            {({ currentUser, currentRoles, updateValue, updateRoles }) => (
                <Route {...rest} render={
                    (props) => {
                        const path = props.match.path.toLowerCase()
                        // if refresh happened and need to retrieve lost user credentials from localStorage
                        if (currentUser == '') {
                            const user = localStorage.getItem('currentUser')
                            if (user !== null) { // found in localStorage
                                updateValue(user)
                                const userRoles = localStorage.getItem('currentRoles')
                                updateRoles(userRoles)
                            } else { // not authorized
                                if ((path == '/') || (path == '/blog'))
                                    return <Component {...props} />
                                console.log('NOT LOGGED IN')
                                return <Redirect to={{
                                    pathname: '/Authorization',
                                    state: {
                                        from: props.location
                                    }
                                }} />
                            }
                        }
                        if ((currentRoles.includes('admin')) || (currentRoles.includes('editor'))) {
                            console.log(`Nothing is true, everything is permitted`)
                            return <Component {...props} />
                        } else { // if just a user
                            if (path == '/newsmanager') {
                                console.log('Not authorized')
                                return <Redirect to={{
                                    pathname: '/Dashboard',
                                    state: {
                                        from: props.location
                                    }
                                }} />
                            }
                        }
                        return <Component {...props} />
                    }
                } />
            )}
        </UserContext.Consumer>
    )
}