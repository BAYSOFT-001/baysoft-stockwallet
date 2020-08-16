import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import { Typography  } from '@material-ui/core';

import {
    Paper,
    Toolbar,
    TableContainer,
    Table,
    TableHead,
    TableBody,
    TableRow,
    TableCell,
    TableSortLabel,
    TablePagination
} from '@material-ui/core';

import { withStyles } from '@material-ui/core/styles';

import EnchancedTable from '../../molecules/EnhancedTable';

import ApiConnectedTable from '../../organisms/ApiConnectedTable';

const TableRowStriped = withStyles((theme) => ({
    root: {
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
    },
}))(TableRow);

class IndexPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <ApiConnectedTable endpoint={'https://localhost:4101/api/samples'}/>
                <hr/>
                <Paper>
                    <Toolbar>
                        <Typography variant="h6" noWrap>Samples</Typography>
                    </Toolbar>
                    <TableContainer>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>
                                        <TableSortLabel>Header 1</TableSortLabel>
                                    </TableCell>
                                    <TableCell>
                                        <TableSortLabel>Header 2</TableSortLabel>
                                    </TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                <TableRowStriped>
                                    <TableCell>row 1 content 1</TableCell>
                                    <TableCell>row 1 content 2</TableCell>
                                </TableRowStriped>
                                <TableRowStriped>
                                    <TableCell>row 2 content 1</TableCell>
                                    <TableCell>row 2 content 2</TableCell>
                                </TableRowStriped>
                            </TableBody>
                        </Table>
                    </TableContainer>
                    <TablePagination
                        rowsPerPageOptions={[5, 10, 25]}
                        component="div"
                        count={5}
                        rowsPerPage={5}
                        page={0}
                        //onChangePage={handleChangePage}
                        //onChangeRowsPerPage={handleChangeRowsPerPage}
                    />
                </Paper>
                <hr/>
                <EnchancedTable/>
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(IndexPage);

export const routes = [
    { private: false, name: "SAMPLES", path: "/samples", params: [], component: connectedComponent },
    { private: false, name: "SAMPLES_INDEX", path: "/samples/index", params: [], component: connectedComponent }
];

export default connectedComponent;
