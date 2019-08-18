import React, { Component } from "react"
import { Grid, Paper, Typography, Divider, withStyles } from '@material-ui/core'
import useStyles from './Styles/makeStyles.js'

class NewsDetail extends Component {
    constructor() {
        super();
        this.state = {
            newsDetails: {}, isFetching: true, error: null
        }
    }

    componentDidMount() {
        const { newsId } = this.props.match.params;
        console.log("Requested id: " + newsId)

        fetch(`/api/news/${newsId}`)
            .then(response => response.json())
            .then(result => {
                this.setState({ newsDetails: result, isFetching: false });
            })
            .catch(e => {
                console.log(e);
                this.setState({ newsDetails: result, isFetching: false, error: e })
            })
    }

    render() {
        const { classes } = this.props;
        const { data, isFetching, error } = this.state;

        if (isFetching) return <div>Идет загрузка...</div>;

        if (error) return <div>{`Error: ${e.message}`}</div>;

        return (
            <main>
                <Grid>
                    <Paper className={classes.paper}>
                        <Typography align="center" variant="h5"> {this.state.newsDetails.headline} </Typography>
                        <Typography align="right" variant="subtitle2" color="textSecondary">
                            {this.state.newsDetails.createDate}
                        </Typography>
                        <img
                            src="https://source.unsplash.com/user/erondu"
                            className={classes.imgCenter}
                        />
                        <Typography gutterBottom align="justify" style={{ textIndent: 30 }}> {this.state.newsDetails.text} </Typography>
                    </Paper>
                </Grid>
            </main>
        );
    }
}

export default withStyles(useStyles)(NewsDetail)