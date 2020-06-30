namespace MainCorreo
{
    partial class FrmPpal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lblIngresando = new System.Windows.Forms.Label();
            this.lstbEstadoEntregado = new System.Windows.Forms.ListBox();
            this.lstbEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lstbEstadoIngresado = new System.Windows.Forms.ListBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.grbPaquete = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.grbEstadoPaquetes.SuspendLayout();
            this.grbPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEstadoPaquetes
            // 
            this.grbEstadoPaquetes.BackColor = System.Drawing.SystemColors.Control;
            this.grbEstadoPaquetes.Controls.Add(this.lblEntregado);
            this.grbEstadoPaquetes.Controls.Add(this.lblEnViaje);
            this.grbEstadoPaquetes.Controls.Add(this.lblIngresando);
            this.grbEstadoPaquetes.Controls.Add(this.lstbEstadoEntregado);
            this.grbEstadoPaquetes.Controls.Add(this.lstbEstadoEnViaje);
            this.grbEstadoPaquetes.Controls.Add(this.lstbEstadoIngresado);
            this.grbEstadoPaquetes.Location = new System.Drawing.Point(10, 12);
            this.grbEstadoPaquetes.Name = "grbEstadoPaquetes";
            this.grbEstadoPaquetes.Size = new System.Drawing.Size(778, 334);
            this.grbEstadoPaquetes.TabIndex = 0;
            this.grbEstadoPaquetes.TabStop = false;
            this.grbEstadoPaquetes.Text = "Estado de Paquetes";
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Location = new System.Drawing.Point(542, 27);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEntregado.TabIndex = 5;
            this.lblEntregado.Text = "Entregado";
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Location = new System.Drawing.Point(279, 27);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(45, 13);
            this.lblEnViaje.TabIndex = 4;
            this.lblEnViaje.Text = "En viaje";
            // 
            // lblIngresando
            // 
            this.lblIngresando.AutoSize = true;
            this.lblIngresando.Location = new System.Drawing.Point(21, 27);
            this.lblIngresando.Name = "lblIngresando";
            this.lblIngresando.Size = new System.Drawing.Size(60, 13);
            this.lblIngresando.TabIndex = 3;
            this.lblIngresando.Text = "Ingresando";
            // 
            // lstbEstadoEntregado
            // 
            this.lstbEstadoEntregado.FormattingEnabled = true;
            this.lstbEstadoEntregado.Location = new System.Drawing.Point(536, 43);
            this.lstbEstadoEntregado.Name = "lstbEstadoEntregado";
            this.lstbEstadoEntregado.Size = new System.Drawing.Size(221, 264);
            this.lstbEstadoEntregado.TabIndex = 2;
            // 
            // lstbEstadoEnViaje
            // 
            this.lstbEstadoEnViaje.FormattingEnabled = true;
            this.lstbEstadoEnViaje.Location = new System.Drawing.Point(282, 43);
            this.lstbEstadoEnViaje.Name = "lstbEstadoEnViaje";
            this.lstbEstadoEnViaje.Size = new System.Drawing.Size(222, 264);
            this.lstbEstadoEnViaje.TabIndex = 1;
            // 
            // lstbEstadoIngresado
            // 
            this.lstbEstadoIngresado.FormattingEnabled = true;
            this.lstbEstadoIngresado.Location = new System.Drawing.Point(24, 43);
            this.lstbEstadoIngresado.Name = "lstbEstadoIngresado";
            this.lstbEstadoIngresado.Size = new System.Drawing.Size(221, 264);
            this.lstbEstadoIngresado.TabIndex = 0;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.BackColor = System.Drawing.SystemColors.Window;
            this.rtbMostrar.Location = new System.Drawing.Point(10, 369);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(484, 158);
            this.rtbMostrar.TabIndex = 1;
            this.rtbMostrar.Text = "";
            // 
            // grbPaquete
            // 
            this.grbPaquete.Controls.Add(this.btnMostrarTodos);
            this.grbPaquete.Controls.Add(this.btnAgregar);
            this.grbPaquete.Controls.Add(this.lblDireccion);
            this.grbPaquete.Controls.Add(this.lblTrackingID);
            this.grbPaquete.Controls.Add(this.txtDireccion);
            this.grbPaquete.Controls.Add(this.mtxtTrackingID);
            this.grbPaquete.Location = new System.Drawing.Point(510, 369);
            this.grbPaquete.Name = "grbPaquete";
            this.grbPaquete.Size = new System.Drawing.Size(278, 158);
            this.grbPaquete.TabIndex = 2;
            this.grbPaquete.TabStop = false;
            this.grbPaquete.Text = "Paquete";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(188, 105);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(84, 23);
            this.btnMostrarTodos.TabIndex = 5;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(188, 44);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(12, 92);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(12, 28);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 2;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(15, 108);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(167, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(15, 44);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(167, 20);
            this.mtxtTrackingID.TabIndex = 0;
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.grbPaquete);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.grbEstadoPaquetes);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Walter Segovia 2D";
            this.grbEstadoPaquetes.ResumeLayout(false);
            this.grbEstadoPaquetes.PerformLayout();
            this.grbPaquete.ResumeLayout(false);
            this.grbPaquete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEstadoPaquetes;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.GroupBox grbPaquete;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.Label lblIngresando;
        private System.Windows.Forms.ListBox lstbEstadoEntregado;
        private System.Windows.Forms.ListBox lstbEstadoEnViaje;
        private System.Windows.Forms.ListBox lstbEstadoIngresado;
    }
}

