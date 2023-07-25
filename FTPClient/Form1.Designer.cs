
namespace FTPClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_conn = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.btn_setPath = new System.Windows.Forms.Button();
            this.lb_ip = new System.Windows.Forms.Label();
            this.lsb_local = new System.Windows.Forms.ListBox();
            this.lsb_server = new System.Windows.Forms.ListBox();
            this.lsb_status = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(60, 21);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(120, 25);
            this.tb_ip.TabIndex = 1;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(441, 21);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(123, 25);
            this.tb_username.TabIndex = 2;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(268, 21);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(59, 25);
            this.tb_port.TabIndex = 3;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(666, 21);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(100, 25);
            this.tb_password.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(355, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(600, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(202, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "端口:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "本地:";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(78, 90);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(303, 25);
            this.tb_path.TabIndex = 10;
            // 
            // btn_conn
            // 
            this.btn_conn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_conn.Location = new System.Drawing.Point(865, 22);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 24);
            this.btn_conn.TabIndex = 11;
            this.btn_conn.Text = "连接";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_download.Location = new System.Drawing.Point(810, 314);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 24);
            this.btn_download.TabIndex = 12;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upload.Location = new System.Drawing.Point(380, 314);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 24);
            this.btn_upload.TabIndex = 13;
            this.btn_upload.Text = "上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_setPath
            // 
            this.btn_setPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_setPath.Location = new System.Drawing.Point(413, 91);
            this.btn_setPath.Name = "btn_setPath";
            this.btn_setPath.Size = new System.Drawing.Size(42, 24);
            this.btn_setPath.TabIndex = 14;
            this.btn_setPath.Text = "...";
            this.btn_setPath.UseVisualStyleBackColor = true;
            this.btn_setPath.Click += new System.EventHandler(this.btn_setPath_Click);
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ip.Location = new System.Drawing.Point(504, 96);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(113, 19);
            this.lb_ip.TabIndex = 15;
            this.lb_ip.Text = "FTP服务器:";
            // 
            // lsb_local
            // 
            this.lsb_local.FormattingEnabled = true;
            this.lsb_local.ItemHeight = 15;
            this.lsb_local.Location = new System.Drawing.Point(78, 143);
            this.lsb_local.Name = "lsb_local";
            this.lsb_local.Size = new System.Drawing.Size(377, 154);
            this.lsb_local.TabIndex = 16;
            // 
            // lsb_server
            // 
            this.lsb_server.FormattingEnabled = true;
            this.lsb_server.ItemHeight = 15;
            this.lsb_server.Location = new System.Drawing.Point(508, 143);
            this.lsb_server.Name = "lsb_server";
            this.lsb_server.Size = new System.Drawing.Size(377, 154);
            this.lsb_server.TabIndex = 17;
            // 
            // lsb_status
            // 
            this.lsb_status.FormattingEnabled = true;
            this.lsb_status.ItemHeight = 15;
            this.lsb_status.Location = new System.Drawing.Point(78, 372);
            this.lsb_status.Name = "lsb_status";
            this.lsb_status.Size = new System.Drawing.Size(807, 109);
            this.lsb_status.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 523);
            this.Controls.Add(this.lsb_status);
            this.Controls.Add(this.lsb_server);
            this.Controls.Add(this.lsb_local);
            this.Controls.Add(this.lb_ip);
            this.Controls.Add(this.btn_setPath);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FTP客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_setPath;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.ListBox lsb_local;
        private System.Windows.Forms.ListBox lsb_server;
        private System.Windows.Forms.ListBox lsb_status;
    }
}

