import { memo } from "react";
import { LayoutProps } from "../type";
import { Flexbox } from 'react-layout-kit';
import Nav from "@/app/@nav/default";

import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const Layout = memo<LayoutProps>(({ children }) => {

    const navigate = useNavigate();
    useEffect(() => {
        document.title = 'Chat';
        const token = localStorage.getItem('token');
        if (!token) {
            navigate('/login');
        }
    }, []);

    return (
        <Flexbox
            height={'100%'}
            horizontal
            style={{
                position: 'relative',
            }}
            width={'100%'}
        >
            <Nav />
            {children}
        </Flexbox>)
})

export default Layout;