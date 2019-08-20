import React, { Component } from 'react'
import {
    Container,
    Typography,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Paper,
    IconButton,
    Button,
    withStyles
} from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete'
import EditIcon from '@material-ui/icons/Edit'

import { TextField, useStyles } from './Styles'

class NewsManager extends Component {
    constructor() {
        super()
        this.state = {
            news: {}, isFetching: true, error: null,
        }
    }

    componentDidMount() {
        const pageSize = 10, pageNum = 1;
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

        const required = value => (value ? undefined : "Заполните это поле")
        return (
            <Container className={classes.root}>
                <Typography variant="h5" align="center" className={classes.managerTitle}>Управление новостями</Typography>
                <Paper className={classes.tablePaper}>
                    <Table className={classes.table}>
                        <TableHead>
                            <TableRow>
                                <TableCell>Миниатюра фото</TableCell>
                                <TableCell align="left">Заголовок новости</TableCell>
                                <TableCell align="left">Дата добавления</TableCell>
                                <TableCell align="left">Действия</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {news.newsList.map((row, index) => (
                                <TableRow key={row.newsId}>
                                    <TableCell>
                                        <img src='https://source.unsplash.com/random' height='150px' />
                                    </TableCell>
                                    <TableCell component="th" scope="row" align="left">{row.headline}</TableCell>
                                    <TableCell align="left">{row.createDate}</TableCell>
                                    <TableCell>
                                        <IconButton>
                                            <EditIcon size="small" />
                                        </IconButton>
                                        <IconButton >
                                            <DeleteIcon size="small" />
                                        </IconButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
            </Container>
        );
    }
}

export default withStyles(useStyles)(NewsManager)
