import React from 'react'
import { Route, Redirect } from 'react-router-dom'
import UserContext from './UserContext'

export const ProtectedRoute = ({ component: Component, ...rest }) => {
    return (
        <UserContext.Consumer>
            {({ currentUser, updateValue }) => (
                <Route {...rest} render={
                    (props) => {
                        if (currentUser != '') {
                            console.log('logged to access route')
                            return <Component {...props} />
                        } else {
                            const user = localStorage.getItem('currentUser')
                            if (user !== null) {
                                updateValue(user)
                                console.log('logged to access route')
                                return <Component {...props} />
                            }
                            console.log('not logged to access route')
                            return <Redirect to={{
                                pathname: '/Authorization',
                                state: {
                                    from: props.location
                                }
                            }} />
                        }
                    }
                } />
            )}
        </UserContext.Consumer>
    )
}