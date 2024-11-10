import { memo } from 'react';
import { DEFAULT_INBOX_AVATAR } from '@/const/meta';
import { INBOX_SESSION_ID } from '@/const/session';
import { SESSION_CHAT_URL } from '@/const/url';
import { useSessionStore } from '@/store/session';

import ListItem from '../ListItem';
import { Link } from 'react-router-dom';
import { useIsMobile } from '@/hooks/useIsMobile';
import { useSwitchSession } from '@/hooks/useSwitchSession';

const Inbox = memo(() => {
  const mobile = useIsMobile();
  const activeId = useSessionStore((s) => s.activeId);
  const switchSession = useSwitchSession();
  return (
    <Link
      aria-label={'默认会话'}
      to={SESSION_CHAT_URL(INBOX_SESSION_ID, mobile)}
      onClick={(e) => {
        e.preventDefault();
        switchSession(INBOX_SESSION_ID);
      }}
    >
      <ListItem
        active={activeId.toString() === INBOX_SESSION_ID.toString()}
        avatar={DEFAULT_INBOX_AVATAR}
        title={'默认会话'}
      />
    </Link>
  );
});

export default Inbox;
