import React, { Component } from 'react';
import { connect } from 'react-redux';
import clsx from 'clsx';
import {
    lighten,
    withStyles,
    Paper,
    Toolbar,
    Tooltip,
    Typography,
    IconButton,    TableContainer,
    Table,
    TableHead,
    TableRow,
    TableCell,
    Checkbox,
    TableSortLabel,
    TableBody,
    TablePagination
} from '@material-ui/core';

import {
    Delete,
    Edit,
    FilterList
} from '@material-ui/icons';

const TableRowStriped = withStyles((theme) => ({
    root: {
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
    },
}))(TableRow);

const config = {
    title: 'List of samples',
    endpoint: 'https://localhost:4101/api/samples?pagesize=5',
    id: 'sampleID',
    dense: false,
    columns: [{
        id: 'description',
        isNumeric: false,
        disablePadding: false,
        label: 'Description'
    }]
};
//const config = {
//    title: 'List of sectors',
//    endpoint: 'https://localhost:4101/api/sectors?pagesize=5',
//    id: 'sectorID',
//    dense: false,
//    columns: [{
//        id: 'description',
//        isNumeric: false,
//        disablePadding: false,
//        label: 'Description'
//    }]
//};

//const config = {
//    title: 'List of products',
//    endpoint: 'https://localhost:8101/api/products?pagesize=5',
//    id: 'productID',
//    dense: false,
//    columns: [{
//        id: 'name',
//        isNumeric: false,
//        disablePadding: false,
//        label: 'Name'
//    }, {
//        id: 'amount',
//        isNumeric: true,
//        disablePadding: false,
//        label: 'Amount'
//    }, {
//        id: 'value',
//        isNumeric: true,
//        disablePadding: false,
//        label: 'Value (R$)'
//    }]
//};

class ApiConnectedTable extends Component {
    constructor() {
        super();
        this.state = {
            resultCount: 0,
            response: {
                request: {
                    route: {},
                    searchProperties: {
                        query: '',
                        strict: false,
                        phrase: false
                    },
                    ordenation: {},
                    pagination: {
                        size: 5,
                        number: 1
                    },
                    responseProperties: []
                },
                data: {},
            },
            selected: [],
            rowCount: 0
        };
    };
    componentDidMount() {
        this.getData();
    };
    getData = () => {
        fetch(config.endpoint)
            .then(response => response.json())
            .then(data => {
                this.setState({ response: data });
            });
    };
    handleRequestSort = (property) => (event) => {
        //const isAsc = orderBy === property && order === 'asc';
        //setOrder(isAsc ? 'desc' : 'asc');
        //setOrderBy(property);
    };
    handleSelectAllClick = (event) => {
        //if (event.target.checked) {
        //    const newSelecteds = rows.map((n) => n.name);
        //    setSelected(newSelecteds);
        //    return;
        //}
        //setSelected([]);
    };
    handleChangePage = (event, newPage) => {
        //setPage(newPage);
    };

    handleChangeRowsPerPage = (event) => {
        //setRowsPerPage(parseInt(event.target.value, 10));
        //setPage(0);
    };
    render() {
        const { response, selected, rowCount } = this.state;
        const { classes } = this.props;
        console.log(classes);
        const emptyRows = response.request.pagination.size - response.data.length;
        return (
            <div className={classes.main.root}>
                <Paper className={classes.main.paper}>
                    <Toolbar
                        className={clsx(classes.toolbar.root, {
                            [classes.toolbar.highlight]: selected.length > 0,
                        })}
                    >
                        {selected.length > 0 ? (
                            <Typography className={classes.toolbar.title} color="inherit" variant="subtitle1" component="div">
                                {selected.length} {selected.length > 1 ? 'itens selecionados' : 'item selecionado'}
                            </Typography>
                        ) : (
                                <Typography className={classes.toolbar.title} variant="h6" id="tableTitle" component="div">
                                    {config.title}
                                </Typography>
                            )}

                        {selected.length > 0 && selected.length === 1 ? (
                            <Tooltip title="Editar">
                                <IconButton aria-label="edit">
                                    <Edit />
                                </IconButton>
                            </Tooltip>) : (null)
                        }

                        {selected.length > 0 ? (
                            <Tooltip title="Excluir">
                                <IconButton aria-label="delete">
                                    <Delete />
                                </IconButton>
                            </Tooltip>
                        ) : (
                                <Tooltip title="Filter list">
                                    <IconButton aria-label="filter list">
                                        <FilterList />
                                    </IconButton>
                                </Tooltip>
                            )}
                    </Toolbar>
                    <TableContainer>
                        <Table
                            className={classes.main.table}
                            aria-labelledby="tableTitle"
                            size={config.dense ? 'small' : 'medium'}
                            aria-label="api table"
                        >
                            <TableHead>
                                <TableRow>
                                    <TableCell padding="checkbox">
                                        <Checkbox
                                            indeterminate={selected.length > 0 && selected.length < rowCount}
                                            checked={rowCount > 0 && selected.length === rowCount}
                                            onChange={this.handleSelectAllClick}
                                            inputProps={{ 'aria-label': 'select all desserts' }}
                                        />
                                    </TableCell>
                                    {
                                        config.columns.map((column) => (
                                            <TableCell
                                                key={column.id}
                                                align={column.isNumeric ? 'right' : 'left'}
                                                padding={column.disablePadding ? 'none' : 'default'}
                                                sortDirection={response.request.ordenation.orderBy === column.id ? response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : false}
                                            >
                                                <TableSortLabel
                                                    active={response.request.ordenation.orderBy === column.id}
                                                    direction={response.request.ordenation.orderBy === column.id ? response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : 'asc'}
                                                    onClick={this.handleRequestSort(column.id)}
                                                >
                                                    {column.label}
                                                    {response.request.ordenation.orderBy === column.id ? (
                                                        <span className={classes.main.visuallyHidden}>
                                                            {response.request.ordenation.order === 'ascending' ? 'sorted ascending' : 'sorted descending'}
                                                        </span>
                                                    ) : null}
                                                </TableSortLabel>
                                            </TableCell>
                                        ))}
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {response !== undefined && response !== null && response.statusCode === 200 ? response.data.map((value, index) => {
                                    const isItemSelected = selected.indexOf(value[config.id]) !== -1;
                                    const labelId = `enhanced-table-checkbox-${index}`;
                                    return (
                                        <TableRowStriped
                                            hover
                                            role="checkbox"
                                            aria-checked={isItemSelected}
                                            tabIndex={-1}
                                            key={value[config.id]}
                                            selected={isItemSelected}
                                        >
                                            <TableCell padding="checkbox">
                                                <Checkbox
                                                    checked={isItemSelected}
                                                    inputProps={{ 'aria-labelledby': labelId }}
                                                />
                                            </TableCell>
                                            {config.columns.map(column => {
                                                const cellId = column.id + '-' + value[config.id];
                                                return (<TableCell key={cellId} align={column.isNumeric ? 'right' : 'left'}>{value[column.id]}</TableCell>)
                                            })}

                                        </TableRowStriped>
                                    )
                                }) : null}
                                {emptyRows > 0 && (
                                    <TableRow style={{ height: (config.dense ? 33 : 53) * emptyRows }}>
                                        <TableCell colSpan={6} />
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </TableContainer>
                    {response !== undefined && response !== null && response.statusCode === 200 ? (
                        <TablePagination
                            rowsPerPageOptions={[5, 10, 25]}
                            component="div"
                            count={response.resultCount}
                            rowsPerPage={response.request.pagination.size}
                            page={response.request.pagination.number - 1}
                            onChangePage={this.handleChangePage}
                            onChangeRowsPerPage={this.handleChangeRowsPerPage}
                        />)
                        : null}
                </Paper>
            </div>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const styles = theme => ({
    main: {
        root: {
            width: '100%',
        },
        paper: {
            width: '100%',
            marginBottom: theme.spacing(2),
        },
        table: {
            minWidth: 750,
        },
        visuallyHidden: {
            border: 0,
            clip: 'rect(0,0,0,0)',
            height: 1,
            margin: -1,
            overflow: 'hidden',
            padding: 0,
            position: 'absolute',
            top: 20,
            width: 1,
        }
    },
    toolbar: {
        root: {
            paddingLeft: theme.spacing(2),
            paddingRight: theme.spacing(1),
        },
        highlight:
            theme.palette.type === 'light'
                ? {
                    color: theme.palette.secondary.main,
                    backgroundColor: lighten(theme.palette.secondary.light, 0.85),
                }
                : {
                    color: theme.palette.text.primary,
                    backgroundColor: theme.palette.secondary.dark,
                },
        title: {
            flex: '1 1 100%',
        },
    }
});

const connectedComponent = connect(mapStateToProps)(withStyles(styles)(ApiConnectedTable));

export default connectedComponent;
