const useStyles = theme => ({
    // root: {
    //     flexGrow: 1
    // },

    // menuButton: {
    //     marginRight: theme.spacing(2),
    // },
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
    // toolbar: {
    //     borderBottom: `1px solid ${theme.palette.divider}`,
    // },
    // toolbarTitle: {
    //     flex: 1,
    // },
    // toolbarSecondary: {
    //     justifyContent: 'space-between',
    //     overflowX: 'auto',
    // },
    // toolbarLink: {
    //     padding: theme.spacing(1),
    //     flexShrink: 0,
    // },
    // overlay: {
    //     position: 'absolute',
    //     top: 0,
    //     bottom: 0,
    //     right: 0,
    //     left: 0,
    //     backgroundColor: 'rgba(0,0,0,.3)',
    // },
    // mainFeaturedPostContent: {
    //     position: 'relative',
    //     padding: theme.spacing(3),
    //     [theme.breakpoints.up('md')]: {
    //         padding: theme.spacing(6),
    //         paddingRight: 0,
    //     },
    // },

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
    // markdown: {
    //     ...theme.typography.body2,
    //     padding: theme.spacing(3, 0),
    // },
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
    }
    // previewImage: {
    //     height: 200,
    //     margin: 5,
    //     flex: 1,
    //     align: 'center'
    // },
    // previewNews: {
    //     marginTop: 5,
    //     marginBottom: 5
    // },
    // previewNewsDescr: {
    //     marginTop: 5,
    //     display: 'flex'
    // }
});

export default useStyles;