import { type LobeHubProps } from '@lobehub/ui/brand';
import { memo } from 'react';

import { ORG_NAME } from '@/const/branding';

export const OrgBrand = memo<LobeHubProps>(() => {
    return <span>{ORG_NAME}</span>;
});
