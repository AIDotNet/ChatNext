import { Empty } from 'antd';
import { memo } from 'react';
import { Center } from 'react-layout-kit';

import { SESSION_CHAT_URL } from '@/const/url';
import { useSwitchSession } from '@/hooks/useSwitchSession';
import { useSessionStore } from '@/store/session';
import { sessionSelectors } from '@/store/session/selectors';
import { LobeAgentSession } from '@/types/session';

import SkeletonList from '../../SkeletonList';
import AddButton from './AddButton';
import SessionItem from './Item';
import { Link } from 'react-router-dom';
import { useIsMobile } from '@/hooks/useIsMobile';

interface SessionListProps {
  dataSource?: LobeAgentSession[];
  groupId?: string;
  showAddButton?: boolean;
}
const SessionList = memo<SessionListProps>(({ dataSource, groupId, showAddButton = true }) => {

  const isInit = useSessionStore(sessionSelectors.isSessionListInit);
  const mobile = useIsMobile();

  const switchSession = useSwitchSession();

  const isEmpty = !dataSource || dataSource.length === 0;
  return !isInit ? (
    <SkeletonList />
  ) : !isEmpty ? (
    dataSource.map(({ id }) => (<Link
      to={SESSION_CHAT_URL(id ?? -1, mobile)}
      onClick={(e) => {
        e.preventDefault();
        switchSession(id ?? -1);
      }}
    >
      <SessionItem id={id ?? -1} />
    </Link>
    ))
  ) : <AddButton groupId={groupId} />;
});

export default SessionList;
