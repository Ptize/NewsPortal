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
import AddIcon from '@material-ui/icons/AddTwoTone'
import DeleteIcon from '@material-ui/icons/Delete'
import EditIcon from '@material-ui/icons/Edit'
import { Form, Field } from 'react-final-form'

import { TextField, useStyles } from './Styles'

class NewsManager extends Component {
    constructor() {
        super()
        this.state = {
            news: {}, isFetching: true, error: null,
            itemSelected: '0',
            openDeletion: false,
            openAdding: false
        }
        this.handleOpenDeletion = this.handleOpenDeletion.bind(this)
        this.handleCloseDeletion = this.handleCloseDeletion.bind(this)

        this.handleToggleAdding = this.handleToggleAdding.bind(this)
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

    handleOpenDeletion(selectedNews) {
        this.setState({ itemSelected: selectedNews, openDeletion: true })
    }

    handleCloseDeletion() {
        console.log("Btn close")
        this.setState({ openDeletion: false })
    }

    handleToggleAdding() {
        this.setState({ openAdding: !this.state.openAdding })
    }

    render() {
        const sleep = ms => new Promise(resolve => setTimeout(resolve, ms))
        const required = value => (value ? undefined : "Заполните это поле")
        const pageSize = 10, pageNum = 1

        const handleConfirmAdding = async values => {
            await sleep(300)
            console.log(values)

            fetch(`/api/news/`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(values)
            })
                .then(res => res.text())
                .then(res => console.log(res))
            this.handleToggleAdding()

            return fetch(`/api/news/list/pageSize=${pageSize}/pageNum=${pageNum}`)
                .then(response => response.json())
                .then(result => {
                    this.setState({ news: result })
                })
                .catch(e => {
                    console.log(e)
                    this.setState({ news: result, error: e })
                })
        }

        const handleConfirmDeletion = () => {
            const newsId = this.state.itemSelected.newsId
            this.handleCloseDeletion()
            return fetch(`/api/news/${newsId}`, { method: 'DELETE' })
                .then(res => res.text())
                .then(res => {
                    console.log(res)
                    fetch(`/api/news/list/pageSize=${pageSize}/pageNum=${pageNum}`)
                        .then(response => response.json())
                        .then(result => {
                            this.setState({ news: result })
                        })
                        .catch(e => {
                            console.log(e)
                            this.setState({ news: result, error: e })
                        })
                })
        }

        const { classes } = this.props
        const { news, isFetching, error } = this.state

        if (isFetching) return <div> Идет загрузка... </div>

        if (error) return <div>{`Ошибка при попытке получения списка новостей: ${e.message}`}</div>

        return (
            <Container className={classes.root}>
                <Typography variant="h5" align="center" className={classes.managerTitle}>Управление новостями</Typography>
                <IconButton onClick={this.handleToggleAdding}>
                    <AddIcon fontSize="large" />
                </IconButton>
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
                                        <IconButton >
                                            <EditIcon size="small" />
                                        </IconButton>
                                        <IconButton onClick={() => this.handleOpenDeletion(row)} >
                                            <DeleteIcon size="small" />
                                        </IconButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
                {/* Dialog for managing adding */}
                <Dialog
                    open={this.state.openAdding}
                    onClose={this.handleToggleAdding}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description">
                    <DialogTitle id="alert-dialog-title" align="center">{"Добавление новости"}</DialogTitle>
                    <DialogContent>
                        <Form
                            onSubmit={handleConfirmAdding}
                            render={({ handleSubmit, form, submitting, pristine, values }) => (
                                <form onSubmit={handleSubmit}>
                                    <div className={classes.fields}>
                                        <Field
                                            name="headline"
                                            component={TextField}
                                            validate={required}
                                            type="text"
                                            label="Заголовок"
                                            multiline
                                            rows="2"
                                            className={classes.fieldControl}
                                        />
                                    </div>
                                    <div className={classes.fields}>
                                        <Field
                                            name="review"
                                            component={TextField}
                                            validate={required}
                                            type="text"
                                            label="Краткое ревью"
                                            multiline
                                            rows="5"
                                            className={classes.fieldControl}
                                        />
                                    </div>
                                    <div className={classes.fields}>
                                        <Field
                                            name="text"
                                            component={TextField}
                                            validate={required}
                                            type="text"
                                            label="Текст"
                                            multiline
                                            rows="13"
                                            className={classes.fieldControl}
                                        />
                                    </div>
                                    <div className={classes.button}>
                                        <Button onClick={this.handleToggleAdding} color="secondary">
                                            Отменить
                                        </Button>
                                        <Button color="primary" type="submit" disabled={submitting || pristine}>
                                            Подтвердить
                                        </Button>
                                    </div>
                                </form>
                            )}
                        />
                    </DialogContent>
                </Dialog>
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
                        <Button onClick={handleConfirmDeletion} color="secondary">
                            Удалить
                        </Button>
                    </DialogActions>
                </Dialog>
            </Container>
        )
    }
}

export default withStyles(useStyles)(NewsManager)