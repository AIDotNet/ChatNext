
import { SearchBar } from '@lobehub/ui';
import { memo } from 'react';

import { useSessionStore } from '@/store/session';

const SessionSearchBar = memo<{ mobile?: boolean }>(({ mobile }) => {
    const [keywords, useSearchSessions, updateSearchKeywords] = useSessionStore((s) => [
        s.sessionSearchKeywords,
        s.useSearchSessions,
        s.updateSearchKeywords,
    ]);

    const { isValidating } = useSearchSessions(keywords);

    return (
        <SearchBar
            allowClear
            enableShortKey={!mobile}
            loading={isValidating}
            onChange={(e) => {
                updateSearchKeywords(e.target.value);
            }}
            placeholder={'搜索会话'}
            shortKey={'k'}
            spotlight={!mobile}
            type={mobile ? 'block' : 'ghost'}
            value={keywords}
        />
    );
});

export default SessionSearchBar;
