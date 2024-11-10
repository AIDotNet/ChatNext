import { createStyles } from 'antd-style';
import { memo } from 'react';
import { Flexbox, FlexboxProps } from 'react-layout-kit';

import { ORG_NAME } from '@/const/branding';

const useStyles = createStyles(({ token, css }) => ({
    logoLink: css`
    line-height: 1;
    color: inherit;

    &:hover {
      color: ${token.colorLink};
    }
  `,
}));

const BrandWatermark = memo<Omit<FlexboxProps, 'children'>>(({ style, ...rest }) => {
    const { styles, theme } = useStyles();
    return (
        <Flexbox
            align={'center'}
            flex={'none'}
            gap={4}
            horizontal
            style={{ color: theme.colorTextDescription, fontSize: 12, ...style }}
            {...rest}
        >
            <span>Powered by</span>
            <span>{ORG_NAME}</span>
        </Flexbox>
    );
});

export default BrandWatermark;
