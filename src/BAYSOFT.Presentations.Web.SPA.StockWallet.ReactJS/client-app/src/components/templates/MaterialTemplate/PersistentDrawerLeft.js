﻿import React from 'react';
import { connect, useSelector } from 'react-redux';
import { bindActionCreators } from 'redux';

import { push } from 'connected-react-router'

import { ApplicationActionType } from '../../../state/actions';

import clsx from 'clsx';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import Link from '@material-ui/core/Link';
import Drawer from '@material-ui/core/Drawer';
import CssBaseline from '@material-ui/core/CssBaseline';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import List from '@material-ui/core/List';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import MailIcon from '@material-ui/icons/Mail';

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
    },
    appBar: {
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
    },
    appBarShift: {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: drawerWidth,
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    hide: {
        display: 'none',
    },
    drawer: {
        width: drawerWidth,
        flexShrink: 0,
    },
    drawerPaper: {
        width: drawerWidth,
    },
    drawerHeader: {
        display: 'flex',
        alignItems: 'center',
        padding: theme.spacing(0, 1),
        // necessary for content to be below app bar
        ...theme.mixins.toolbar,
        justifyContent: 'flex-end',
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        marginLeft: -drawerWidth,
    },
    contentShift: {
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
        marginLeft: 0,
    },
}));

function handleClick(event) {
    event.preventDefault();
    console.info('You clicked a breadcrumb.');
}

function breadcrumbs(items) {
    return (
        <Breadcrumbs aria-label="breadcrumb">
            {
                items.map((item, index) => {
                    console.log(index);
                    if (index == items.length) {
                        return (<Typography key={index} color="textPrimary">{items.title}</Typography>);
                    } else {
                        return (<Link key={index} color="inherit" href="/" onClick={handleClick}>{item.title}</Link>);
                    }
                })
            }            
        </Breadcrumbs>
    );
}
function PersistentDrawerLeft(props) {
    const classes = useStyles();
    const theme = useTheme();
    const application = useSelector(state => state.applicationState.application);

    const handleDrawerOpen = () => {
        props.ApplicationMenuOpen();
    };

    const handleDrawerClose = () => {
        props.ApplicationMenuClose();
    };

    return (
        <div className={classes.root}>
            <CssBaseline />
            <AppBar
                position="fixed"
                className={clsx(classes.appBar, {
                    [classes.appBarShift]: application.menu.isOpen,
                })}
            >
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        className={clsx(classes.menuButton, application.menu.isOpen && classes.hide)}
                    >
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6" noWrap>
                        { application.name }
                    </Typography>
                </Toolbar>
            </AppBar>
            <Drawer
                className={classes.drawer}
                variant="persistent"
                anchor="left"
                open={application.menu.isOpen}
                classes={{
                    paper: classes.drawerPaper,
                }}
            >
                <div className={classes.drawerHeader}>
                    <IconButton onClick={handleDrawerClose}>
                        {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
                    </IconButton>
                </div>
                <Divider />
                <List>
                    {application.menu.items.map((item, index) => (
                        <ListItem button key={item.name}
                            selected={item.route == props.pathname}
                            onClick={() => props.push(item.route) }
                            disabled={item.isDisabled}>
                            <ListItemIcon>{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                            <ListItemText primary={item.name} />
                        </ListItem>
                    ))}
                </List>
                <Divider />
                <List>
                    {['All mail', 'Trash', 'Spam'].map((text, index) => (
                        <ListItem button key={text}>
                            <ListItemIcon>{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItem>
                    ))}
                </List>
            </Drawer>
            <main
                className={clsx(classes.content, {
                    [classes.contentShift]: application.menu.isOpen,
                })}
            >
                <div className={classes.drawerHeader} />

                {breadcrumbs([{ title: 'Home' }, {title:'Index'}])}

                {props.children}
            </main>
        </div>
    );
}

const {
    ApplicationMenuOpen,
    ApplicationMenuClose
} = ApplicationActionType.actions;

const mapStateToProps = store => ({
    application: store.applicationState.application,
    pathname: store.router.location.pathname,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        ApplicationMenuOpen,
        ApplicationMenuClose,
        push
    }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(PersistentDrawerLeft);