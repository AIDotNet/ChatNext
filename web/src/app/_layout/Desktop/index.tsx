import { memo } from "react";
import { LayoutProps } from "../type";
import { Flexbox } from 'react-layout-kit';


const Layout = memo<LayoutProps>(({ children }) => {

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