import React, { Component } from "react";
import Typography from '@material-ui/core/Typography';

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
        const { data, isFetching, error } = this.state;

        if (isFetching) return <div>Идет загрузка...</div>;

        if (error) return <div>{`Error: ${e.message}`}</div>;

        return (
            <main>
                <Typography align="center" variant="h5"> {this.state.newsDetails.headline} </Typography>
                <Typography align="right" variant="subtitle2">{this.state.newsDetails.createDate}</Typography>
                <Typography>{this.state.newsDetails.text}</Typography>
            </main>
        );
    }
}
export default NewsDetail;