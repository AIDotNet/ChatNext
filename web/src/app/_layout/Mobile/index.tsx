import { memo } from "react";
import { LayoutProps } from "../type";


const Layout = memo<LayoutProps>(({ children }) => {
    return (<>
        {children}
    </>)
})

export default Layout;