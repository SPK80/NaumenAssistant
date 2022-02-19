using System.Windows.Forms;
using System.Collections;
using System;

namespace ActiveMenus.MenuItems
{
    public abstract class BaseMenuItem : ToolStripMenuItem
    {
        protected ListBox listBox => (Owner as ContextMenuStrip)?.SourceControl as ListBox;
        protected IList listItems => (listBox.DataSource as IList) ?? listBox.Items;
        protected bool confirmation(string additive = "") => withoutСonfirmation || MessageBox.Show($"{Text} {additive}?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes;

        protected bool withoutСonfirmation = false;

        protected bool itemSelected => listBox?.SelectedItem == null ? false : true;
        protected abstract bool needSelectedItem { get; }

        /// <summary>
        /// OnClick с обработкой исключений в дочерних обработчиках
        /// при исключении вызывается ErrorMessage
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            try
            {
                base.OnClick(e);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return;
            }            
        }
        protected virtual void ErrorMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private ContextMenuStrip contextMenuStrip = null;

        protected override void OnOwnerChanged(EventArgs e)
        {
            //при изменении Owner - отписка на старом
            //и подписка на новом Owner

            ContextMenuStrip oldContextMenuStrip = contextMenuStrip;
            contextMenuStrip = (Owner as ContextMenuStrip);

            if (contextMenuStrip != oldContextMenuStrip)
            {
                if (oldContextMenuStrip!=null)
                {
                    oldContextMenuStrip.Opening -= cmsOpening;
                }
                if (contextMenuStrip != null)
                {
                    contextMenuStrip.Opening += cmsOpening;
                }
            }

            base.OnOwnerChanged(e);
        }
        
        private void cmsOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBox == null) return;
            // показываем только нужные пункты меню
            if (needSelectedItem)
            {
                Visible = listBox.SelectedItem != null;
            }
            else
            {
                Visible = listBox.SelectedItem == null;
            }
        }
    }

    public class ItemEventArgs : EventArgs
    {
        public object Item { get; set; } = null;

        /// <summary>
        /// Если TRUE то действие выполняется без подтверждения
        /// </summary>
        public bool WithoutСonfirmation { get; set; } = false;
    }    

}
