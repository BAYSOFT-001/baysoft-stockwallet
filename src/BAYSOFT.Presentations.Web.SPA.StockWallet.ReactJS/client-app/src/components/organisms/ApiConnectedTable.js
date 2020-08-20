import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import clsx from 'clsx';
import {
    lighten,
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
    FilterList,
    Add
} from '@material-ui/icons';

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
    },
    tableHeadRoot: {
        fontWeight: 'bold' 
    }
}));

const createContext = (config) => {
    return {
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
            data: []
        },
        selected: [],
        endpoint: config.endpoint,
        parameters: [],
        generateEndpoit: (context) => {
            let pageSize = `pagesize=${context.response.request.pagination.size}`;
            let pageNumber = `pagenumber=${context.response.request.pagination.number}`;
            return context.endpoint + '?' + pageSize + '&' + pageNumber;
        }
    }
};

const ApiConnectedTable = props => {
    const { config } = props;
    const tableContext = createContext(config);
    const classes = useStyles();
    const [context, setContext] = React.useState(tableContext);
    const emptyRows = context.response.request.pagination.size - context.response.data.length;
    const loadData = (endpoint) => {
        console.log(endpoint);
        fetch(endpoint)
            .then(response => response.json())
            .then(data => {
                setContext({
                    ...context,
                    response: data
                });
            });
    };
    const handleRequestSort = (property) => (event) => {
        console.log('click: handleRequestSort');
    };
    const handleSelectAllClick = (event) => {
        if (event.target.checked) {
            const newSelecteds = context.response.data.map((value) => value[config.id]);
            console.log(newSelecteds);
            setContext({ ...context, selected: newSelecteds });
            return;
        }
        setContext({ ...context, selected: [] });
    };
    const handleClick = (event, id) => {
        const selectedIndex = context.selected.indexOf(id);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(context.selected, id);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(context.selected.slice(1));
        } else if (selectedIndex === context.selected.length - 1) {
            newSelected = newSelected.concat(context.selected.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                context.selected.slice(0, selectedIndex),
                context.selected.slice(selectedIndex + 1),
            );
        }
        setContext({ ...context, selected: newSelected });
    };
    const handleChangePage = (event, newPage) => {
        console.log(newPage);
        setContext({
            ...context,
            response: {
                ...context.response,
                request: {
                    ...context.response.request,
                    pagination: {
                        ...context.response.request.pagination,
                        number: newPage+1
                    }
                }
            }
        });
    };
    const handleChangeRowsPerPage = (event) => {
        setContext({
            ...context,
            response: {
                ...context.response,
                request: {
                    ...context.response.request,
                    pagination: {
                        size: event.target.value,
                        number: 1
                    }
                }
            }
        });
    };
    const handleClickAdd = (event) => {
        config.actions['add'].handler();
    };
    const handleClickFilter = (event) => {
        console.log('click: handleClickFilter');
    };
    const handleClickEdit = (event) => {
        config.actions['edit'].handler();
    };
    const handleClickDelete = (event) => {
        config.actions['delete'].handler();
    };
    const allowAction = (action) => {
        return config.actions !== undefined && config.actions[action] !== undefined;
    }
    useEffect(() => {
        if (context) {
            setContext({ ...context, filterQuery: context.generateEndpoit(context) });
        }
    }, [context.response.request]);
    useEffect(() => {
        if (context) {
            loadData(context.filterQuery);
        }
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

                    {allowAction('edit') && context.selected.length > 0 && context.selected.length === 1 ? (
                        <Tooltip title="Editar">
                            <IconButton aria-label="edit" onClick={handleClickEdit}>
                                <Edit />
                            </IconButton>
                        </Tooltip>) : (null)
                    }

                    {allowAction('delete') && context.selected.length > 0 ? (
                        <Tooltip title="Excluir">
                            <IconButton aria-label="delete" onClick={handleClickDelete}>
                                <Delete />
                            </IconButton>
                        </Tooltip>
                    ) : (
                            <React.Fragment>
                                {allowAction('add') ? (
                                    <Tooltip title="Add item">
                                        <IconButton aria-label="add item" onClick={handleClickAdd}>
                                            <Add />
                                        </IconButton>
                                    </Tooltip>) : null}
                                <Tooltip title="Filter list">
                                    <IconButton aria-label="filter list" onClick={handleClickFilter}>
                                        <FilterList />
                                    </IconButton>
                                </Tooltip>
                            </React.Fragment>
                        )}
                </Toolbar>
                <TableContainer>
                    <Table
                        className={classes.mainTable}
                        aria-labelledby="tableTitle"
                        size={config.dense ? 'small' : 'medium'}
                        aria-label="api table"
                    >
                        <TableHead className={classes.tableHeadRoot}>
                            <TableRow>
                                <TableCell padding="checkbox">
                                    <Checkbox
                                        indeterminate={context.selected.length > 0 && context.selected.length < context.response.data.length}
                                        checked={context.response.data.length > 0 && context.selected.length === context.response.data.length}
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
                                                style={{ fontWeight: 'bold' }}
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
                                    <TableRow
                                        hover
                                        onClick={(event) => handleClick(event, value[config.id])}
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

                                    </TableRow>
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
