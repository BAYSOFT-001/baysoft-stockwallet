import React, { useEffect, useState, useCallback } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import clsx from 'clsx';
import { debounce } from 'debounce';
import { CreateApiService, CreateApiFilter, GetRequest } from '../../state/actions/apiModelWrapper/actions';

import {
    lighten,
    fade,
    makeStyles,
    Paper,
    Toolbar,
    Tooltip,
    Typography,
    IconButton,
    TableContainer,
    Table,
    TableHead,
    TableRow,
    TableCell,
    Checkbox,
    TableSortLabel,
    TableBody,
    TablePagination,
    InputBase
} from '@material-ui/core';

import {
    Delete,
    Edit,
    FilterList,
    Add,
    Search
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
    },
    search: {
        position: 'relative',
        borderRadius: theme.shape.borderRadius,
        backgroundColor: fade(theme.palette.common.black, 0.05),
        '&:hover': {
            backgroundColor: fade(theme.palette.common.black, 0.10),
        },
        marginRight: theme.spacing(2),
        marginLeft: 0,
        width: '100%',
        [theme.breakpoints.up('sm')]: {
            marginLeft: theme.spacing(3),
            width: 'auto',
        },
    },
    searchIcon: {
        padding: theme.spacing(0, 2),
        height: '100%',
        position: 'absolute',
        pointerEvents: 'none',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    inputRoot: {
        color: 'inherit',
    },
    inputInput: {
        padding: theme.spacing(1, 1, 1, 0),
        // vertical padding + font size from searchIcon
        paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('md')]: {
            width: '20ch',
        },
    },
}));

const ApiConnectedTable = props => {
    const { config } = props;
    const classes = useStyles();

    const api = props.CreateApiService(`${config.configId}-service`, config.endPoint);
    const filter = props.CreateApiFilter(`${config.configId}-filter`);

    const [requestUrl, setRequestUrl] = useState(config.endPoint);
    const [request, setRequest] = useState(props.GetRequest(requestUrl));

    const [query, setQuery] = useState('');
    const [selectedRows, setSelectedRows] = useState([]);
    const emptyRows = request && request.response ? request.response.request.pagination.size - request.response.data.length : 5;
    console.log(requestUrl);
    console.log(request);
    const loadData = () => {
        setRequestUrl(api.GetByFilter(filter));
    };
    const debounceQuery = useCallback(debounce((value) => {
        let strict = request && request.response ? request.response.request.searchProperties.strict : false;
        let phrase = request && request.response ? request.response.request.searchProperties.phrase : false;
        filter.setSearch(value, strict, phrase);

        loadData();
    }, 3000, false), []);
    const handleRequestSort = (property) => (event) => {
        const isAscending = property === request.response.request.ordenation.orderBy && request.response.request.ordenation.order === 'ascending';
        const order = isAscending ? 'descending' : 'ascending';

        filter.setOrdenation(property, order);

        loadData();
    };
    const handleSelectAllClick = (event) => {
        if (event.target.checked) {
            const newSelecteds = request.response.data.map((value) => value[config.id]);
            console.log(newSelecteds);
            setSelectedRows(newSelecteds);
            return;
        }
        setSelectedRows([]);
    };
    const handleClick = (event, id) => {
        const selectedIndex = selectedRows.indexOf(id);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selectedRows, id);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(selectedRows.slice(1));
        } else if (selectedIndex === selectedRows.length - 1) {
            newSelected = newSelected.concat(selectedRows.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                selectedRows.slice(0, selectedIndex),
                selectedRows.slice(selectedIndex + 1),
            );
        }
        setSelectedRows(newSelected);
    };
    const handleChangePage = (event, newPage) => {
        filter.setPagination(request.response.request.pagination.size, newPage + 1);

        loadData();
    };
    const handleChangeRowsPerPage = (event) => {
        filter.setPagination(event.target.value, 1);

        loadData();
    };
    const handleClickAdd = (event) => {
        config.actions['add'].handler();
    };
    const handleClickFilter = (event) => {
        console.log('click: handleClickFilter');
    };
    const handleClickEdit = (id) => (event) => {
        config.actions['edit'].handler(id);
    };
    const handleClickDelete = (event) => {
        config.actions['delete'].handler();
    };
    const handleQuery = (event) => {
        setQuery(event.target.value);
    };
    const allowAction = (action) => {
        return config.actions !== undefined && config.actions[action] !== undefined;
    }
    useEffect(() => {
        loadData();
    });
    useEffect(() => {
        setRequest(props.GetRequest(requestUrl));
    }, [requestUrl]);
    useEffect(() => {
        debounceQuery(query);
    }, [query, debounceQuery]);
    return (
        <div className={classes.mainRoot}>
            <Paper className={classes.mainPaper}>
                <Toolbar
                    className={clsx(classes.toolbarRoot, {
                        [classes.toolbarHighlight]: selectedRows.length > 0,
                    })}
                >
                    {selectedRows.length > 0 ? (
                        <Typography className={classes.toolbarTitle} color="inherit" variant="subtitle1" component="div">
                            {selectedRows.length} {selectedRows.length > 1 ? 'itens selecionados' : 'item selecionado'}
                        </Typography>
                    ) : (
                            <Typography className={classes.toolbarTitle} variant="h6" id="tableTitle" component="div">
                                {config.title}
                            </Typography>
                        )}
                    <div className={classes.search}>
                        <div className={classes.searchIcon}>
                            <Search />
                        </div>
                        <InputBase
                            placeholder="Search…"
                            classes={{
                                root: classes.inputRoot,
                                input: classes.inputInput,
                            }}
                            inputProps={{ 'aria-label': 'search' }}
                            value={query}
                            onChange={handleQuery}
                        />
                    </div>

                    {allowAction('edit') && selectedRows.length > 0 && selectedRows.length === 1 ? (
                        <Tooltip title="Editar">
                            <IconButton aria-label="edit" onClick={handleClickEdit(selectedRows[0])}>
                                <Edit />
                            </IconButton>
                        </Tooltip>) : (null)
                    }

                    {allowAction('delete') && selectedRows.length > 0 ? (
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
                                        indeterminate={selectedRows.length > 0 && selectedRows.length < request.response.data.length}
                                        checked={request && request.response && request.response.data.length > 0 && selectedRows.length === request.response.data.length}
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
                                            sortDirection={request && request.response && request.response.request.ordenation.orderBy === column.id ? request.response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : false}
                                        >
                                            <TableSortLabel
                                                style={{ fontWeight: 'bold' }}
                                                active={request && request.response && request.response.request.ordenation.orderBy === column.id}
                                                direction={request && request.response && request.response.request.ordenation.orderBy === column.id ? request.response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : 'asc'}
                                                onClick={handleRequestSort(column.id)}
                                            >
                                                {column.label}
                                                {request && request.response && request.response.request.ordenation.orderBy === column.id ? (
                                                    <span className={classes.mainVisuallyHidden}>
                                                        {request && request.response.request.ordenation.order === 'ascending' ? 'sorted ascending' : 'sorted descending'}
                                                    </span>
                                                ) : null}
                                            </TableSortLabel>
                                        </TableCell>
                                    ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {request && request.response && request.response !== undefined && request.response !== null && request.response.statusCode === 200 ? request.response.data.map((value, index) => {
                                const isItemSelected = selectedRows.indexOf(value[config.id]) !== -1;
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
                {request && request.response && request.response !== undefined && request.response !== null && request.response.statusCode === 200 ? (
                    <TablePagination
                        rowsPerPageOptions={[5, 10, 25]}
                        component="div"
                        count={request.response.resultCount}
                        rowsPerPage={request.response.request.pagination.size}
                        page={request.response.request.pagination.number - 1}
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

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        CreateApiService,
        CreateApiFilter,
        GetRequest
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(ApiConnectedTable);

export default connectedComponent;
