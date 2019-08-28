import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import {
  Paper,
  Typography,
  Grid,
  Divider,
  withStyles,
  Hidden,
  CardActionArea,
  CardContent,
  CardMedia,
  Card
} from '@material-ui/core'
import useStyles from './Styles/makeStyles.js'

class Blog extends Component {
  constructor() {
    super()
    this.state = {
      news: {}, isFetching: true, error: null
    }
  }

  componentDidMount() {
    const pageSize = 10, pageNum = 1
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
    const { classes } = this.props
    const { news, isFetching, error } = this.state

    if (isFetching) return <div> Идет загрузка... </div>

    if (error) return <div>{`Ошибка при попытке получения списка новостей: ${e.message}`}</div>

    return (
      <main>
        <Grid container spacing={5} className={classes.mainGrid}>
          {/* Main content */}
          <Grid item xs={12} md={8}>
            <Typography variant="h5" gutterBottom>
              Блог последних новостей
            </Typography>
            <Divider />
            {news.newsList.map(post => (
              <Grid item key={post.newsId} xl>
                <CardActionArea className={classes.cardArea} >
                  <Link to={"/Blog/News/" + post.newsId} className={classes.link}>
                    <Card className={classes.card}>
                      <Hidden xsDown>
                        <CardMedia
                          className={classes.cardMedia}
                          image="https://source.unsplash.com/random"
                          title="Image title"
                        />
                      </Hidden>
                      <div className={classes.cardDetails}>
                        <CardContent>
                          <Typography component="h2" variant="h5">
                            {post.headline}
                          </Typography>
                          <Typography variant="subtitle1" paragraph>
                            {post.headline}
                          </Typography>
                          <Typography variant="subtitle1" color="secondary">
                            Продолжение...
                        </Typography>
                        </CardContent>
                      </div>
                    </Card>
                  </Link>
                </CardActionArea>
                <Divider />
              </Grid>
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
    )
  }
}

export default withStyles(useStyles)(Blog)