import { Icon, Modal, type ModalProps, SortableList } from '@lobehub/ui';
import { Button } from 'antd';
import { createStyles } from 'antd-style';
import isEqual from 'fast-deep-equal';
import { Plus } from 'lucide-react';
import { memo, useState } from 'react';
import { Flexbox } from 'react-layout-kit';

import { useSessionStore } from '@/store/session';
import { sessionGroupSelectors } from '@/store/session/selectors';
import { SessionGroupItem } from '@/types/session';

import GroupItem from './GroupItem';

const useStyles = createStyles(({ css, token }) => ({
  container: css`
    height: 36px;
    padding-inline: 8px;
    border-radius: ${token.borderRadius}px;
    transition: background 0.2s ease-in-out;

    &:hover {
      background: ${token.colorFillTertiary};
    }
  `,
}));

const ConfigGroupModal = memo<ModalProps>(({ open, onCancel }) => {
  const { styles } = useStyles();
  const sessionGroupItems = useSessionStore(sessionGroupSelectors.sessionGroupItems, isEqual);
  const [addSessionGroup, updateSessionGroupSort] = useSessionStore((s) => [
    s.addSessionGroup,
    s.updateSessionGroupSort,
  ]);
  const [loading, setLoading] = useState(false);

  return (
    <Modal
      allowFullscreen
      footer={null}
      onCancel={onCancel}
      open={open}
      title={'分组设置'}
      width={400}
    >
      <Flexbox>
        <SortableList
          items={sessionGroupItems}
          onChange={(items: SessionGroupItem[]) => {
            updateSessionGroupSort(items);
          }}
          renderItem={(item: SessionGroupItem) => (
            <SortableList.Item
              align={'center'}
              className={styles.container}
              gap={4}
              horizontal
              id={item.id}
              justify={'space-between'}
            >
              <GroupItem {...item} />
            </SortableList.Item>
          )}
        />
        <Button
          block
          icon={<Icon icon={Plus} />}
          loading={loading}
          onClick={async () => {
            setLoading(true);
            await addSessionGroup('新分组');
            setLoading(false);
          }}
        >
          添加分组
        </Button>
      </Flexbox>
    </Modal>
  );
});

export default ConfigGroupModal;
