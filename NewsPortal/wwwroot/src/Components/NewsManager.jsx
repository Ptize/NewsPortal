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
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
    DialogTitle,
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
            itemSelected: '0',
            openDeletion: false,
            openEditing: false
        }
        this.handleOpenDeletion = this.handleOpenDeletion.bind(this)
        this.handleCloseDeletion = this.handleCloseDeletion.bind(this)
        this.handleConfirmDeletion = this.handleConfirmDeletion.bind(this)
    }

    componentDidMount() {
        const pageSize = 10, pageNum = 1
        fetch(`/api/news/list/pageSize=${pageSize}/pageNum=${pageNum}`)
            .then(response => response.json())
            .then(result => {
                this.setState({ news: result, isFetching: false })
            })
            .catch(e => {
                console.log(e)
                this.setState({ news: result, isFetching: false, error: e })
            })
    }

    handleOpenDeletion(newsId) {
        this.setState({ itemSelected: newsId, openDeletion: true })
    }

    handleCloseDeletion() {
        console.log("Btn close")
        this.setState({ openDeletion: false })
    }

    handleConfirmDeletion() {
        const newsId = this.state.itemSelected
        console.log("Btn delete")
        console.log(newsId)
        this.setState({ openDeletion: false })
        fetch(`/api/news/${newsId}`, { method: 'DELETE' })

        const pageSize = 10, pageNum = 1
        fetch(`/api/news/list/pageSize=${pageSize}/pageNum=${pageNum}`)
            .then(response => response.json())
            .then(result => {
                this.setState({ news: result, isFetching: false })
            })
            .catch(e => {
                console.log(e)
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
                                    <TableCell align="left">{row.createData}</TableCell>
                                    <TableCell>
                                        <IconButton>
                                            <EditIcon size="small" />
                                        </IconButton>
                                        <IconButton onClick={() => this.handleOpenDeletion(row.newsId)} >
                                            <DeleteIcon size="small" />
                                        </IconButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
                {/* Dialog for managing deletion */}
                <Dialog
                    open={this.state.openDeletion}
                    onClose={this.handleCloseDeletion}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description">
                    <DialogTitle id="alert-dialog-title">{"Вы уверены, что хотите удалить новость?"}</DialogTitle>
                    <DialogContent>
                        <DialogContentText id="alert-dialog-description">
                            Учтите, что отменить это действие будет невозможно
                        </DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleCloseDeletion} color="primary" autoFocus>
                            Отменить
                        </Button>
                        <Button onClick={this.handleConfirmDeletion.bind(this)} color="secondary">
                            Удалить
                        </Button>
                    </DialogActions>
                </Dialog>
            </Container>
        );
    }
}

export default withStyles(useStyles)(NewsManager)