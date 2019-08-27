const useStyles = theme => ({
    // Header styling
    link: {
        textDecoration: 'none',
        color: '#FFF'
    },
    title: {
        flexGrow: 1,
        color: theme.palette.common.white,
    },
    // Footer
    footer: {
        backgroundColor: '#F5F5F5',
        marginTop: theme.spacing(8),
        padding: theme.spacing(6, 0),
    },
    // Blog page's styling
    mainGrid: {
        marginTop: theme.spacing(3),
    },
    cardArea: {
        marginTop: theme.spacing(3),
    },
    card: {
        display: 'flex'
    },
    cardDetails: {
        flex: 1,
    },
    cardMedia: {
        width: 160,
    },
    sidebarAboutBox: {
        padding: theme.spacing(2),
        backgroundColor: theme.palette.grey[200],
    },
    sidebarSection: {
        marginTop: theme.spacing(3),
    },
    // NewsDetails page's
    paper: {
        marginTop: theme.spacing(1),
        padding: theme.spacing(2)
    },
    imgCenter: {
        height: 500,
        display: 'block',
        marginLeft: 'auto',
        marginRight: 'auto',
        marginTop: theme.spacing(2),
        marginBottom: theme.spacing(4),
    },
    // Registration and Authorization pages'
    forms: {
        padding: theme.spacing(2)
    },
    fields: {
        marginTop: theme.spacing(1)
    },
    buttons: {
        display: 'flex'
    },
    button: {
        marginTop: theme.spacing(3),
        marginRight: theme.spacing(1)
    },
    // NewsManager page
    managerTitle: {
        marginTop: theme.spacing(1)
    },
    tablePaper: {
        width: '100%',
        marginTop: theme.spacing(3),
        overflowX: 'auto',
    },
    table: {
        minWidth: 650,
    },
    fieldControl: {
        width: 500
    },
    // Dashboard
    dashTitle: {
        marginTop: theme.spacing(2)
    },
    dashboard: {
        minHeight: 800
    }
});

export default useStyles;