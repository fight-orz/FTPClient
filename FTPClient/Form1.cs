using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        //全局变量
        private TcpClient cmdServer, dataServer;
        private NetworkStream cmdStrmWtr, dataStrmWtr;
        private StreamReader cmdStrmRdr, dataStrmRdr;
        private String cmdData;
        private byte[] szData;
        private const String CRLF = "\r\n";
        private bool isContinue = false;
        private bool isConnect = false;
        private int count = 0;

        //获取命令端口返回结果，并记录在lsb_status上
        private String GetStatus()
        {
            String ret = cmdStrmRdr.ReadLine();
            lsb_status.Items.Add(ret);
            lsb_status.SelectedIndex = lsb_status.Items.Count - 1;

            return ret;
        }

        //进入被动模式，并初始化数据端口的输入输出流
        private void OpenDataPort()
        {
            string retstr;
            string[] retArray;
            int dataPort;

            //进入被动模式
            cmdData = "PASV" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            retstr = this.GetStatus();

            //计算数据端口
            retArray = Regex.Split(retstr, ",");
            if (retArray[5][2] != ')')
            {
                retstr = retArray[5].Substring(0, 3);
            }
            else
            {
                retstr=retArray[5].Substring(0,2);
            }
            dataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
            lsb_status.Items.Add("得到数据端口为：" + dataPort);

            //连接到端口
            dataServer = new TcpClient(tb_ip.Text, dataPort);
            dataStrmRdr = new StreamReader(dataServer.GetStream());
            dataStrmWtr = dataServer.GetStream();

        }

        //断开数据端口的连接
        private void CloseDataPort()
        {
            dataStrmRdr.Close();
            dataStrmWtr.Close();
            this.GetStatus();

            cmdData = "ABOR" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.GetStatus();
        }

        //获得/刷新FTP服务器文件列表
        private void GetFTPFile()
        {

            OpenDataPort();

            string absFilePath;

            //List
            cmdData = "LIST" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.GetStatus();

            lsb_server.Items.Clear();
            while ((absFilePath = dataStrmRdr.ReadLine()) != null)
            {
                string[] temp = Regex.Split(absFilePath, " ");
                lsb_server.Items.Add(temp[temp.Length - 1]);
            }

            CloseDataPort();

        }

        //获得/刷新本地文件列表
        private void GetLocalFile()
        {
            lsb_local.Items.Clear();

            if (tb_path.Text == "") { return; }
            var files = Directory.GetFiles(tb_path.Text, "*.*");
            foreach(var file in files)
            {
                Console.WriteLine(file);
                string[] temp = Regex.Split(file, @"\\");
                lsb_local.Items.Add(temp[temp.Length - 1]);
            }
        }

        //建立数据库
        private void CreateMySql()
        {
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes; " +
                                                   "UserId=root; PWD=aaaaaa");
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE FTP;", conn);

            conn.Open();

            //防止第二次启动时再次新建数据库
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("建立数据库成功", "YES");
            }
            catch (Exception)
            {
                conn.Close();
                //MessageBox.Show("建立数据库失败，已存在了", "ERROR");
                //throw;
            }

        }

        //建立数据表
        private void CreateTable() {
            string connStr = "datasource=localhost;port=3306;database=FTP;username=root;password=aaaaaa;";
            string createStatement = "CREATE TABLE FTPInfo (Id INT(4) AUTO_INCREMENT PRIMARY KEY , Name VarChar(512), UpLoad VarChar(512),Count VarChar(512))";
            //string alterStatement = "ALTER TABLE People ADD Sex Boolean";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                //防止第二次启动时再次新建数据表
                try
                {
                    // 建表  
                    using (MySqlCommand cmd = new MySqlCommand(createStatement, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    //MessageBox.Show("建表成功", "YES");
                }
                catch (Exception)
                {
                    //MessageBox.Show("建表失败，已存在", "ERROR");
                    //throw;
                }

            }
        
        }

        //连接数据库连接
        private static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                "datasource=localhost;username=root;" + "password=aaaaaa;database=FTP;"
                );
            connection.Open();
            return connection;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateMySql();
            CreateTable();
        }

        //连接按钮
        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (btn_conn.Text == "连接")
            {
                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                cmdServer = new TcpClient(tb_ip.Text, Convert.ToInt32(tb_port.Text));
                //lsb_status.Items.Clear();

                isConnect = true;

                try
                {
                    cmdStrmRdr = new StreamReader(cmdServer.GetStream());
                    cmdStrmWtr = cmdServer.GetStream();
                    this.GetStatus();

                    string retstr;

                    //登录
                    cmdData = "USER " + tb_username.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    this.GetStatus();

                    cmdData = "PASS " + tb_password.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    retstr = this.GetStatus().Substring(0, 3);

                    if (Convert.ToInt32(retstr) == 530)
                    {
                        throw new InvalidOperationException("账号密码错误！");
                    }

                    this.GetFTPFile();

                    lb_ip.Text = "FTP服务器IP：" + tb_ip.Text;
                    btn_conn.Text = "断开";
                    btn_upload.Enabled = true;
                    btn_download.Enabled = true;

                }
                catch(InvalidOperationException err)
                {
                    lsb_status.Items.Add("错误：" + err.Message.ToString());
                }
                finally
                {
                    Cursor.Current = cr;
                }

            }
            else
            {
                isConnect = false;

                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                //登出
                cmdData = "QUIT" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.GetStatus();

                cmdStrmWtr.Close();
                cmdStrmRdr.Close();

                lb_ip.Text = "FTP服务器：";
                btn_conn.Text = "连接";
                btn_upload.Enabled = false;
                btn_download.Enabled = false;
                lsb_server.Items.Clear();

                Cursor.Current = cr;

            }

        }

        //路径按钮
        private void btn_setPath_Click(object sender, EventArgs e)
        {

            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                lsb_status.Items.Add("选中本地路径：" + path);
            }

            tb_path.Text = path;
            GetLocalFile();

        }

        //上传按钮
        private void btn_upload_Click(object sender, EventArgs e)
        {

            if (tb_path.Text == "" || lsb_local.SelectedIndex < 0)
            {
                MessageBox.Show("请选择上传的文件", "ERROR");
                return;
            }

            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = lsb_local.Items[lsb_local.SelectedIndex].ToString();
            string filePath = tb_path.Text + "\\" + fileName;

            this.OpenDataPort();

            using (MySqlConnection conn = GetConnection())
            {
                string stm = "SELECT * FROM FTPInfo WHERE UpLoad = '1' AND Name = '" + fileName + "' OR Name='null' ORDER BY Id DESC;";
                using (MySqlCommand cmd = new MySqlCommand(stm, conn))
                {
                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    
                    if (ds.Tables[0].Rows[0][1].ToString() == fileName)
                    {
                        count = int.Parse(ds.Tables[0].Rows[0][3].ToString());
                        isContinue = true;
                    }
                    else {
                        isContinue = false;
                    }
                }
                conn.Close();
            }

            if (isContinue == false)
            {

                cmdData = "STOR " + fileName + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.GetStatus();

                FileStream fstrm = new FileStream(filePath, FileMode.Open);

                byte[] fbytes = new byte[1030];
                int cnt = 0;
                while ((cnt = fstrm.Read(fbytes, 0, 1024)) > 0)
                {
                    //传输途中连接中断
                    if (isConnect == false)
                    {
                        using (MySqlConnection conn = GetConnection())
                        {
                            string stm = "INSERT INTO FTPInfo(Name,UpLoad,Count) values('" + fileName + "','1','" + count.ToString() + "');";
                            MySqlCommand cmd = new MySqlCommand(stm, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    dataStrmWtr.Write(fbytes, 0, cnt);
                    count++;
                }
                lsb_status.Items.Add("上传完成！");
                lsb_status.SelectedIndex = lsb_status.Items.Count - 1;
                fstrm.Close();

                this.CloseDataPort();

                this.GetFTPFile();
            }
            else
            {
                //lsb_status.Items.Add("上次上传中断，将继续");
                //lsb_status.SelectedIndex = lsb_status.Items.Count - 1;

                cmdData = "REST " + (count * 1024).ToString() + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);

                this.GetStatus();

                cmdData = "STOR " + fileName + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.GetStatus();

                FileStream fstrm = new FileStream(filePath, FileMode.Append);

                byte[] fbytes = new byte[1030];
                int cnt = 0;
                while ((cnt = fstrm.Read(fbytes, 0, 1024)) > 0)
                {
                    dataStrmWtr.Write(fbytes, 0, cnt);
                    count++;
                }

                using (MySqlConnection conn = GetConnection())
                {
                    string stm = "DELETE FROM FTPInfo WHERE UpLoad = '1' AND Name = '" + fileName + "';";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                lsb_status.Items.Add("上传完成！");
                lsb_status.SelectedIndex = lsb_status.Items.Count - 1;
                fstrm.Close();

                this.CloseDataPort();

                this.GetFTPFile();
            }

            Cursor.Current = cr;

        }

        //下载按钮
        private void btn_download_Click(object sender, EventArgs e)
        {

            if (tb_path.Text == "" || lsb_server.SelectedIndex < 0)
            {
                MessageBox.Show("请选择目标文件和下载路径", "ERROR");
                return;
            }

            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = lsb_server.Items[lsb_server.SelectedIndex].ToString();
            string filePath = tb_path.Text + "\\" + fileName;

            this.OpenDataPort();

            using (MySqlConnection conn = GetConnection())
            {
                string stm = "SELECT * FROM FTPInfo WHERE UpLoad = '0' AND Name = '" + fileName + "' OR Name='null' ORDER BY Id DESC;";
                using (MySqlCommand cmd = new MySqlCommand(stm, conn))
                {
                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);

                    if (ds.Tables[0].Rows[0][1].ToString() == fileName)
                    {
                        count = int.Parse(ds.Tables[0].Rows[0][3].ToString());
                        isContinue = true;
                    }
                    else
                    {
                        isContinue = false;
                    }
                }
                conn.Close();
            }

            //不需要进行断点续传
            if (isContinue == false)
            {

                cmdData = "RETR " + fileName + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);

                this.GetStatus();

                FileStream fstrm = new FileStream(filePath, FileMode.OpenOrCreate);
                //char[] fchars = new char[1030];
                byte[] fbytes = new byte[1030];
                int cnt = 0;

                while ((cnt = dataStrmWtr.Read(fbytes, 0, 1024)) > 0)
                {
                    //传输途中连接中断
                    if (isConnect == false)
                    {
                        using (MySqlConnection conn = GetConnection())
                        {
                            string stm = "INSERT INTO FTPInfo(Name,UpLoad,Count) values('" + fileName + "','0','" + count.ToString() + "';";
                            MySqlCommand cmd = new MySqlCommand(stm, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }

                    //isContinue = true;
                    fstrm.Write(fbytes, 0, cnt);
                    count++;
                }
                //isContinue = false;
                fstrm.Close();
                lsb_status.Items.Add("下载完成！");
                lsb_status.SelectedIndex = lsb_status.Items.Count - 1;

                this.CloseDataPort();
                this.GetLocalFile();
            }
            else
            {
                //lsb_status.Items.Add("上次下载中断，将继续");
                //lsb_status.SelectedIndex = lsb_status.Items.Count - 1;

                cmdData = "REST " + (count*1024).ToString() + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);

                this.GetStatus();

                cmdData = "RETR " + fileName + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);

                this.GetStatus();

                FileStream fstrm = new FileStream(filePath, FileMode.Append);
                //char[] fchars = new char[1030];
                byte[] fbytes = new byte[1030];
                int cnt = 0;

                while ((cnt = dataStrmWtr.Read(fbytes, 0, 1024)) > 0)
                {
                    //isContinue = true;
                    fstrm.Write(fbytes, 0, cnt);
                    count++;
                }
                //isContinue = false;
                fstrm.Close();

                using (MySqlConnection conn = GetConnection())
                {
                    string stm = "DELETE FROM FTPInfo WHERE UpLoad = '0' AND Name = '" + fileName + "';";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                lsb_status.Items.Add("下载完成！");
                lsb_status.SelectedIndex = lsb_status.Items.Count - 1;

                this.CloseDataPort();
                this.GetLocalFile();
            }
  
            Cursor.Current = cr;

        }

    }
}


