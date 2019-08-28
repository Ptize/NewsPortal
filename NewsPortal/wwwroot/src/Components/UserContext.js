import React from 'react'

const UserContext = React.createContext({
    currentUser: '',
    currentRoles: '',
    updateValue: () => {},
    updateRoles: () => {}
})

export const UserProvider = UserContext.Provider
export const UserConsumer = UserContext.Consumer
export default UserContext