import { ActionIcon, EditableText, SortableList } from '@lobehub/ui';
import { App } from 'antd';
import { createStyles } from 'antd-style';
import { PencilLine, Trash } from 'lucide-react';
import { memo, useState } from 'react';

import { useSessionStore } from '@/store/session';
import { SessionGroupItem } from '@/types/session';

const useStyles = createStyles(({ css }) => ({
  content: css`
    position: relative;
    overflow: hidden;
    flex: 1;
  `,
  title: css`
    flex: 1;
    height: 28px;
    line-height: 28px;
    text-align: start;
  `,
}));

const GroupItem = memo<SessionGroupItem>(({ id, name }) => {
  const { styles } = useStyles();
  const { message, modal } = App.useApp();

  const [editing, setEditing] = useState(false);
  const [updateSessionGroupName, removeSessionGroup] = useSessionStore((s) => [
    s.updateSessionGroupName,
    s.removeSessionGroup,
  ]);

  return (
    <>
      <SortableList.DragHandle />
      {!editing ? (
        <>
          <span className={styles.title}>{name}</span>
          <ActionIcon icon={PencilLine} onClick={() => setEditing(true)} size={'small'} />
          <ActionIcon
            icon={Trash}
            onClick={() => {
              modal.confirm({
                centered: true,
                okButtonProps: {
                  danger: true,
                  type: 'primary',
                },
                onOk: async () => {
                  await removeSessionGroup(id);
                },
                title: '删除分组',
              });
            }}
            size={'small'}
          />
        </>
      ) : (
        <EditableText
          editing={editing}
          onChangeEnd={async (input) => {
            if (name !== input) {
              if (!input) return;
              if (input.length === 0 || input.length > 20)
                return message.warning('分组名称长度为1-20个字符');

              await updateSessionGroupName(id, input);
              message.success('分组名称修改成功');
            }
            setEditing(false);
          }}
          onEditingChange={(e) => setEditing(e)}
          showEditIcon={false}
          size={'small'}
          style={{
            height: 28,
          }}
          type={'pure'}
          value={name}
        />
      )}
    </>
  );
});

export default GroupItem;
