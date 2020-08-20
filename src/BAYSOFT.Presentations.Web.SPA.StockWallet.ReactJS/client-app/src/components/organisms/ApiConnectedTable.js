import React, { Component, useEffect } from 'react';
import { connect } from 'react-redux';
import clsx from 'clsx';
import {
    lighten,
    withStyles,
    makeStyles,
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

const useStyles = makeStyles(theme => ({
    mainRoot: {
        width: '100%',
    },
    mainPaper: {
        width: '100%',
        marginBottom: theme.spacing(2),
    },
    mainTable: {
        minWidth: 750,
    },
    mainVisuallyHidden: {
        border: 0,
        clip: 'rect(0,0,0,0)',
        height: 1,
        margin: -1,
        overflow: 'hidden',
        padding: 0,
        position: 'absolute',
        top: 20,
        width: 1,
    },
    toolbarRoot: {
        paddingLeft: theme.spacing(2),
        paddingRight: theme.spacing(1),
    },
    toolbarHighlight:
        theme.palette.type === 'light'
            ? {
                color: theme.palette.secondary.main,
                backgroundColor: lighten(theme.palette.secondary.light, 0.85),
            }
            : {
                color: theme.palette.text.primary,
                backgroundColor: theme.palette.secondary.dark,
            },
    toolbarTitle: {
        flex: '1 1 100%',
    }
}));

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

const tableContext = {
    filterQuery: '',
    response: {
        statusCode: 0,
        internalCode: 0,
        resultCount: 0,
        message: '',
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
        data: [],
    },
    selected: [],
    rowCount: 0
};



const ApiConnectedTable = props => {
    const classes = useStyles();
    const [context, setContext] = React.useState(tableContext);
    const emptyRows = context.response.request.pagination.size - context.response.data.length;
    const loadData = () => {
        fetch(config.endpoint)
            .then(response => response.json())
            .then(data => {
                setContext({ ...context, response: data });
            });
    };
    const handleRequestSort = (property) => (event) => {
        //const isAsc = orderBy === property && order === 'asc';
        //setOrder(isAsc ? 'desc' : 'asc');
        //setOrderBy(property);
    };
    const handleSelectAllClick = (event) => {
        //if (event.target.checked) {
        //    const newSelecteds = rows.map((n) => n.name);
        //    setSelected(newSelecteds);
        //    return;
        //}
        //setSelected([]);
    };
    const handleChangePage = (event, newPage) => {
        //setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        //setRowsPerPage(parseInt(event.target.value, 10));
        //setPage(0);
    };
    useEffect(() => {
        loadData();
    }, [context.filterQuery]);
    return (
        <div className={classes.mainRoot}>
            <Paper className={classes.mainPaper}>
                <Toolbar
                    className={clsx(classes.toolbarRoot, {
                        [classes.toolbarHighlight]: context.selected.length > 0,
                    })}
                >
                    {context.selected.length > 0 ? (
                        <Typography className={classes.toolbarTitle} color="inherit" variant="subtitle1" component="div">
                            {context.selected.length} {context.selected.length > 1 ? 'itens selecionados' : 'item selecionado'}
                        </Typography>
                    ) : (
                            <Typography className={classes.toolbarTitle} variant="h6" id="tableTitle" component="div">
                                {config.title}
                            </Typography>
                        )}

                    {context.selected.length > 0 && context.selected.length === 1 ? (
                        <Tooltip title="Editar">
                            <IconButton aria-label="edit">
                                <Edit />
                            </IconButton>
                        </Tooltip>) : (null)
                    }

                    {context.selected.length > 0 ? (
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
                        className={classes.mainTable}
                        aria-labelledby="tableTitle"
                        size={config.dense ? 'small' : 'medium'}
                        aria-label="api table"
                    >
                        <TableHead>
                            <TableRow>
                                <TableCell padding="checkbox">
                                    <Checkbox
                                        indeterminate={context.selected.length > 0 && context.selected.length < context.rowCount}
                                        checked={context.rowCount > 0 && context.selected.length === context.rowCount}
                                        onChange={handleSelectAllClick}
                                        inputProps={{ 'aria-label': 'select all desserts' }}
                                    />
                                </TableCell>
                                {
                                    config.columns.map((column) => (
                                        <TableCell
                                            key={column.id}
                                            align={column.isNumeric ? 'right' : 'left'}
                                            padding={column.disablePadding ? 'none' : 'default'}
                                            sortDirection={context.response.request.ordenation.orderBy === column.id ? context.response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : false}
                                        >
                                            <TableSortLabel
                                                active={context.response.request.ordenation.orderBy === column.id}
                                                direction={context.response.request.ordenation.orderBy === column.id ? context.response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : 'asc'}
                                                onClick={handleRequestSort(column.id)}
                                            >
                                                {column.label}
                                                {context.response.request.ordenation.orderBy === column.id ? (
                                                    <span className={classes.main.visuallyHidden}>
                                                        {context.response.request.ordenation.order === 'ascending' ? 'sorted ascending' : 'sorted descending'}
                                                    </span>
                                                ) : null}
                                            </TableSortLabel>
                                        </TableCell>
                                    ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {context.response !== undefined && context.response !== null && context.response.statusCode === 200 ? context.response.data.map((value, index) => {
                                const isItemSelected = context.selected.indexOf(value[config.id]) !== -1;
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
                {context.response !== undefined && context.response !== null && context.response.statusCode === 200 ? (
                    <TablePagination
                        rowsPerPageOptions={[5, 10, 25]}
                        component="div"
                        count={context.response.resultCount}
                        rowsPerPage={context.response.request.pagination.size}
                        page={context.response.request.pagination.number - 1}
                        onChangePage={handleChangePage}
                        onChangeRowsPerPage={handleChangeRowsPerPage}
                    />)
                    : null}
            </Paper>
        </div>
    );
};

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(ApiConnectedTable);

export default connectedComponent;
