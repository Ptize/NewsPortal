import React, { Component } from 'react';
import { Link } from "react-router-dom";
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Hidden from '@material-ui/core/Hidden';
import Button from '@material-ui/core/Button';
import Divider from '@material-ui/core/Divider';
import Container from '@material-ui/core/Container';
import { withStyles } from '@material-ui/core/styles';
import useStyles from './makeStyles.js';

class Blog extends Component {
  constructor() {
    super();
    this.state = {
      news: {}, isFetching: true, error: null
    };
  }

  componentDidMount() {
    const pageSize = 5, pageNum = 1;
    fetch(`/api/news/list/pageSize=${pageSize}/pageNum=${pageNum}`)
      .then(response => response.json())
      .then(result => {
        this.setState({ news: result, isFetching: false });
      })
      .catch(e => {
        console.log(e);
        this.setState({ news: result, isFetching: false, error: e })
      })
  }

  render() {
    const { classes } = this.props;
    const { data, isFetching, error } = this.state;

    if (isFetching) return <div>Идет загрузка...</div>;

    if (error) return <div>{`Error: ${e.message}`}</div>;

    return (
      <React.Fragment>
        <main>
          <Grid container spacing={5} className={classes.mainGrid}>
            {/* Main content */}
            <Grid item xs={12} md={8}>
              <Typography variant="h5" gutterBottom>
                Блог последних новостей
            </Typography>
              <Divider />

              {this.state.news.newsList.map((post, index) => (
                <div className={classes.previewNews} key={index}>
                  <Typography variant="h6">
                    {post.headline}
                  </Typography>

                  <div className={classes.previewNewsDescr}>
                    <Link to={"/Blog/News/" + post.newsId}>
                      Смотреть продолжение...
                  </Link>
                  </div>
                  <Divider />
                </div>
              ))}
            </Grid>
            {/* End main content */}
            {/* Sidebar */}
            <Grid item xs={12} md={4}>
              <Paper elevation={0} className={classes.sidebarAboutBox}>
                <Typography variant="h6" gutterBottom>
                  О портале
              </Typography>
                <Typography>
                  NewsPortal - это новостной портал, посвященный важнейшим новостям всех отраслей. Только проверенная информация.
              </Typography>
              </Paper>
            </Grid>
            {/* End sidebar */}
          </Grid>
        </main>
      </React.Fragment>
    )
  }
}

export default withStyles(useStyles)(Blog);