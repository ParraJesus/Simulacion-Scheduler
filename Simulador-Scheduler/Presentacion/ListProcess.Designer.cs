namespace Scheduler_Simulator.Presentacion
{
    partial class ListProcess
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.pbState = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.lblWaitTime = new System.Windows.Forms.Label();
            this.lblBurstTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 120);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 89);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "[Nombre]";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1
            // 
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(0, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(200, 31);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Nombre:";
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblState.ForeColor = System.Drawing.Color.White;
            this.lblState.Location = new System.Drawing.Point(200, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(300, 31);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "Estado";
            // 
            // pbState
            // 
            this.pbState.Enabled = false;
            this.pbState.Location = new System.Drawing.Point(206, 34);
            this.pbState.Name = "pbState";
            this.pbState.Size = new System.Drawing.Size(281, 23);
            this.pbState.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(200, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(138, 31);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Tiempo de espera:";
            // 
            // lblWaitTime
            // 
            this.lblWaitTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWaitTime.ForeColor = System.Drawing.Color.White;
            this.lblWaitTime.Location = new System.Drawing.Point(344, 60);
            this.lblWaitTime.Name = "lblWaitTime";
            this.lblWaitTime.Size = new System.Drawing.Size(138, 31);
            this.lblWaitTime.TabIndex = 6;
            this.lblWaitTime.Text = "[Tiempo]";
            // 
            // lblBurstTime
            // 
            this.lblBurstTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBurstTime.ForeColor = System.Drawing.Color.White;
            this.lblBurstTime.Location = new System.Drawing.Point(344, 89);
            this.lblBurstTime.Name = "lblBurstTime";
            this.lblBurstTime.Size = new System.Drawing.Size(138, 31);
            this.lblBurstTime.TabIndex = 8;
            this.lblBurstTime.Text = "[Tiempo]";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(200, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tiempo de ráfaga:";
            // 
            // ListProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.lblBurstTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWaitTime);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.pbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.panel1);
            this.Name = "ListProcess";
            this.Size = new System.Drawing.Size(500, 120);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lbl1;
        private Label lblTitle;
        private Label lblState;
        private ProgressBar pbState;
        private System.Windows.Forms.Timer timer1;
        private Label Label1;
        private Label lblWaitTime;
        private Label lblBurstTime;
        private Label label3;
    }
}
