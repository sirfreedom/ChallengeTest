namespace WinFormDisegnPattern
{
    partial class frmTestPattern
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFactoryPattern = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.btnAbstractFactory = new System.Windows.Forms.Button();
            this.btnStrategy = new System.Windows.Forms.Button();
            this.btnStatePatterm = new System.Windows.Forms.Button();
            this.btnDecorator = new System.Windows.Forms.Button();
            this.btnFlyWeight = new System.Windows.Forms.Button();
            this.txtVisor = new System.Windows.Forms.TextBox();
            this.btnSingleton = new System.Windows.Forms.Button();
            this.btnLoadBalancer = new System.Windows.Forms.Button();
            this.btnInversionDeDependencias1 = new System.Windows.Forms.Button();
            this.btnInversionDeDepencias2 = new System.Windows.Forms.Button();
            this.btnObserver1 = new System.Windows.Forms.Button();
            this.btnPolimorfismo1 = new System.Windows.Forms.Button();
            this.btnThread1 = new System.Windows.Forms.Button();
            this.btnThreadConcept = new System.Windows.Forms.Button();
            this.btnThreadingConceptConThreading = new System.Windows.Forms.Button();
            this.btnSincronizacionThread = new System.Windows.Forms.Button();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.btnOpenClose3 = new System.Windows.Forms.Button();
            this.btnLiskov = new System.Windows.Forms.Button();
            this.btnSegregacionDeInterfaces = new System.Windows.Forms.Button();
            this.btnChainOfResponsibility = new System.Windows.Forms.Button();
            this.btnPrototype = new System.Windows.Forms.Button();
            this.btnPolimorfismo2 = new System.Windows.Forms.Button();
            this.btnRepository = new System.Windows.Forms.Button();
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnIterator1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFactoryPattern
            // 
            this.btnFactoryPattern.Location = new System.Drawing.Point(32, 22);
            this.btnFactoryPattern.Name = "btnFactoryPattern";
            this.btnFactoryPattern.Size = new System.Drawing.Size(125, 30);
            this.btnFactoryPattern.TabIndex = 1;
            this.btnFactoryPattern.Text = "FactoryPattern";
            this.btnFactoryPattern.UseVisualStyleBackColor = true;
            this.btnFactoryPattern.Click += new System.EventHandler(this.btnFactoryPattern_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.Location = new System.Drawing.Point(32, 58);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(125, 30);
            this.btnBuilder.TabIndex = 3;
            this.btnBuilder.Text = "Builder";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // btnAbstractFactory
            // 
            this.btnAbstractFactory.Location = new System.Drawing.Point(32, 94);
            this.btnAbstractFactory.Name = "btnAbstractFactory";
            this.btnAbstractFactory.Size = new System.Drawing.Size(125, 30);
            this.btnAbstractFactory.TabIndex = 2;
            this.btnAbstractFactory.Text = "Abstract Factory";
            this.btnAbstractFactory.UseVisualStyleBackColor = true;
            this.btnAbstractFactory.Click += new System.EventHandler(this.btnAbstractFactory_Click);
            // 
            // btnStrategy
            // 
            this.btnStrategy.Location = new System.Drawing.Point(32, 201);
            this.btnStrategy.Name = "btnStrategy";
            this.btnStrategy.Size = new System.Drawing.Size(125, 30);
            this.btnStrategy.TabIndex = 7;
            this.btnStrategy.Text = "Strategy";
            this.btnStrategy.UseVisualStyleBackColor = true;
            this.btnStrategy.Click += new System.EventHandler(this.btnStrategy_Click);
            // 
            // btnStatePatterm
            // 
            this.btnStatePatterm.Location = new System.Drawing.Point(32, 166);
            this.btnStatePatterm.Name = "btnStatePatterm";
            this.btnStatePatterm.Size = new System.Drawing.Size(125, 30);
            this.btnStatePatterm.TabIndex = 6;
            this.btnStatePatterm.Text = "State Pattern";
            this.btnStatePatterm.UseVisualStyleBackColor = true;
            this.btnStatePatterm.Click += new System.EventHandler(this.btnStatePatterm_Click);
            // 
            // btnDecorator
            // 
            this.btnDecorator.Location = new System.Drawing.Point(32, 130);
            this.btnDecorator.Name = "btnDecorator";
            this.btnDecorator.Size = new System.Drawing.Size(125, 30);
            this.btnDecorator.TabIndex = 5;
            this.btnDecorator.Text = "Decorator";
            this.btnDecorator.UseVisualStyleBackColor = true;
            this.btnDecorator.Click += new System.EventHandler(this.btnDecorator_Click);
            // 
            // btnFlyWeight
            // 
            this.btnFlyWeight.Location = new System.Drawing.Point(32, 237);
            this.btnFlyWeight.Name = "btnFlyWeight";
            this.btnFlyWeight.Size = new System.Drawing.Size(125, 30);
            this.btnFlyWeight.TabIndex = 4;
            this.btnFlyWeight.Text = "Fly Weight";
            this.btnFlyWeight.UseVisualStyleBackColor = true;
            this.btnFlyWeight.Click += new System.EventHandler(this.btnFlyWeight_Click);
            // 
            // txtVisor
            // 
            this.txtVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVisor.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtVisor.Location = new System.Drawing.Point(579, 2);
            this.txtVisor.MaxLength = 8000;
            this.txtVisor.Multiline = true;
            this.txtVisor.Name = "txtVisor";
            this.txtVisor.ReadOnly = true;
            this.txtVisor.Size = new System.Drawing.Size(589, 480);
            this.txtVisor.TabIndex = 8;
            // 
            // btnSingleton
            // 
            this.btnSingleton.Location = new System.Drawing.Point(32, 272);
            this.btnSingleton.Name = "btnSingleton";
            this.btnSingleton.Size = new System.Drawing.Size(125, 30);
            this.btnSingleton.TabIndex = 9;
            this.btnSingleton.Text = "Singleton";
            this.btnSingleton.UseVisualStyleBackColor = true;
            this.btnSingleton.Click += new System.EventHandler(this.btnSingleton_Click);
            // 
            // btnLoadBalancer
            // 
            this.btnLoadBalancer.Location = new System.Drawing.Point(164, 22);
            this.btnLoadBalancer.Name = "btnLoadBalancer";
            this.btnLoadBalancer.Size = new System.Drawing.Size(156, 30);
            this.btnLoadBalancer.TabIndex = 10;
            this.btnLoadBalancer.Text = "Load Balancer";
            this.btnLoadBalancer.UseVisualStyleBackColor = true;
            this.btnLoadBalancer.Click += new System.EventHandler(this.btnLoadBalancer_Click);
            // 
            // btnInversionDeDependencias1
            // 
            this.btnInversionDeDependencias1.Location = new System.Drawing.Point(326, 22);
            this.btnInversionDeDependencias1.Name = "btnInversionDeDependencias1";
            this.btnInversionDeDependencias1.Size = new System.Drawing.Size(157, 30);
            this.btnInversionDeDependencias1.TabIndex = 13;
            this.btnInversionDeDependencias1.Text = "Inversion de Dependencias 1";
            this.btnInversionDeDependencias1.UseVisualStyleBackColor = true;
            this.btnInversionDeDependencias1.Click += new System.EventHandler(this.btnInversionDeDependencias1_Click);
            // 
            // btnInversionDeDepencias2
            // 
            this.btnInversionDeDepencias2.Location = new System.Drawing.Point(327, 58);
            this.btnInversionDeDepencias2.Name = "btnInversionDeDepencias2";
            this.btnInversionDeDepencias2.Size = new System.Drawing.Size(157, 30);
            this.btnInversionDeDepencias2.TabIndex = 14;
            this.btnInversionDeDepencias2.Text = "Inversion de Dependencias 2";
            this.btnInversionDeDepencias2.UseVisualStyleBackColor = true;
            this.btnInversionDeDepencias2.Click += new System.EventHandler(this.btnInversionDeDepencias2_Click);
            // 
            // btnObserver1
            // 
            this.btnObserver1.Location = new System.Drawing.Point(163, 58);
            this.btnObserver1.Name = "btnObserver1";
            this.btnObserver1.Size = new System.Drawing.Size(157, 30);
            this.btnObserver1.TabIndex = 15;
            this.btnObserver1.Text = "Observer 1";
            this.btnObserver1.UseVisualStyleBackColor = true;
            this.btnObserver1.Click += new System.EventHandler(this.btnObserver1_Click);
            // 
            // btnPolimorfismo1
            // 
            this.btnPolimorfismo1.Location = new System.Drawing.Point(163, 94);
            this.btnPolimorfismo1.Name = "btnPolimorfismo1";
            this.btnPolimorfismo1.Size = new System.Drawing.Size(157, 30);
            this.btnPolimorfismo1.TabIndex = 16;
            this.btnPolimorfismo1.Text = "Polimorfismo 1";
            this.btnPolimorfismo1.UseVisualStyleBackColor = true;
            this.btnPolimorfismo1.Click += new System.EventHandler(this.btnPolimorfismo1_Click);
            // 
            // btnThread1
            // 
            this.btnThread1.Location = new System.Drawing.Point(164, 166);
            this.btnThread1.Name = "btnThread1";
            this.btnThread1.Size = new System.Drawing.Size(157, 30);
            this.btnThread1.TabIndex = 17;
            this.btnThread1.Text = "Thread 1";
            this.btnThread1.UseVisualStyleBackColor = true;
            this.btnThread1.Click += new System.EventHandler(this.btnThread1_Click);
            // 
            // btnThreadConcept
            // 
            this.btnThreadConcept.Location = new System.Drawing.Point(164, 202);
            this.btnThreadConcept.Name = "btnThreadConcept";
            this.btnThreadConcept.Size = new System.Drawing.Size(157, 41);
            this.btnThreadConcept.TabIndex = 18;
            this.btnThreadConcept.Text = "Thread Concept Sin Threading";
            this.btnThreadConcept.UseVisualStyleBackColor = true;
            this.btnThreadConcept.Click += new System.EventHandler(this.btnThreadConcept_Click);
            // 
            // btnThreadingConceptConThreading
            // 
            this.btnThreadingConceptConThreading.Location = new System.Drawing.Point(164, 249);
            this.btnThreadingConceptConThreading.Name = "btnThreadingConceptConThreading";
            this.btnThreadingConceptConThreading.Size = new System.Drawing.Size(157, 41);
            this.btnThreadingConceptConThreading.TabIndex = 19;
            this.btnThreadingConceptConThreading.Text = "Thread Concept Con Threading";
            this.btnThreadingConceptConThreading.UseVisualStyleBackColor = true;
            this.btnThreadingConceptConThreading.Click += new System.EventHandler(this.btnThreadingConceptConThreading_Click);
            // 
            // btnSincronizacionThread
            // 
            this.btnSincronizacionThread.Location = new System.Drawing.Point(327, 237);
            this.btnSincronizacionThread.Name = "btnSincronizacionThread";
            this.btnSincronizacionThread.Size = new System.Drawing.Size(157, 30);
            this.btnSincronizacionThread.TabIndex = 20;
            this.btnSincronizacionThread.Text = "Sincronizacion Thread ";
            this.btnSincronizacionThread.UseVisualStyleBackColor = true;
            this.btnSincronizacionThread.Click += new System.EventHandler(this.btnSincronizacionThread_Click);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(327, 94);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(157, 30);
            this.btnOpenClose.TabIndex = 21;
            this.btnOpenClose.Text = "Open Close";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // btnOpenClose3
            // 
            this.btnOpenClose3.Location = new System.Drawing.Point(327, 130);
            this.btnOpenClose3.Name = "btnOpenClose3";
            this.btnOpenClose3.Size = new System.Drawing.Size(157, 30);
            this.btnOpenClose3.TabIndex = 22;
            this.btnOpenClose3.Text = "Open Close";
            this.btnOpenClose3.UseVisualStyleBackColor = true;
            this.btnOpenClose3.Click += new System.EventHandler(this.btnOpenClose3_Click);
            // 
            // btnLiskov
            // 
            this.btnLiskov.Location = new System.Drawing.Point(327, 165);
            this.btnLiskov.Name = "btnLiskov";
            this.btnLiskov.Size = new System.Drawing.Size(157, 30);
            this.btnLiskov.TabIndex = 23;
            this.btnLiskov.Text = "Liskov";
            this.btnLiskov.UseVisualStyleBackColor = true;
            this.btnLiskov.Click += new System.EventHandler(this.btnLiskov_Click);
            // 
            // btnSegregacionDeInterfaces
            // 
            this.btnSegregacionDeInterfaces.Location = new System.Drawing.Point(327, 201);
            this.btnSegregacionDeInterfaces.Name = "btnSegregacionDeInterfaces";
            this.btnSegregacionDeInterfaces.Size = new System.Drawing.Size(157, 30);
            this.btnSegregacionDeInterfaces.TabIndex = 24;
            this.btnSegregacionDeInterfaces.Text = "Segregacion de interfaces";
            this.btnSegregacionDeInterfaces.UseVisualStyleBackColor = true;
            this.btnSegregacionDeInterfaces.Click += new System.EventHandler(this.btnSegregacionDeInterfaces_Click);
            // 
            // btnChainOfResponsibility
            // 
            this.btnChainOfResponsibility.Location = new System.Drawing.Point(32, 307);
            this.btnChainOfResponsibility.Name = "btnChainOfResponsibility";
            this.btnChainOfResponsibility.Size = new System.Drawing.Size(125, 30);
            this.btnChainOfResponsibility.TabIndex = 25;
            this.btnChainOfResponsibility.Text = "Chain of Responsibility";
            this.btnChainOfResponsibility.UseVisualStyleBackColor = true;
            this.btnChainOfResponsibility.Click += new System.EventHandler(this.btnChainOfResponsibility_Click);
            // 
            // btnPrototype
            // 
            this.btnPrototype.Location = new System.Drawing.Point(32, 343);
            this.btnPrototype.Name = "btnPrototype";
            this.btnPrototype.Size = new System.Drawing.Size(125, 30);
            this.btnPrototype.TabIndex = 26;
            this.btnPrototype.Text = "Prototype";
            this.btnPrototype.UseVisualStyleBackColor = true;
            this.btnPrototype.Click += new System.EventHandler(this.btnPrototype_Click);
            // 
            // btnPolimorfismo2
            // 
            this.btnPolimorfismo2.Location = new System.Drawing.Point(163, 130);
            this.btnPolimorfismo2.Name = "btnPolimorfismo2";
            this.btnPolimorfismo2.Size = new System.Drawing.Size(157, 30);
            this.btnPolimorfismo2.TabIndex = 27;
            this.btnPolimorfismo2.Text = "Polimorfismo 2";
            this.btnPolimorfismo2.UseVisualStyleBackColor = true;
            this.btnPolimorfismo2.Click += new System.EventHandler(this.btnPolimorfismo2_Click);
            // 
            // btnRepository
            // 
            this.btnRepository.Location = new System.Drawing.Point(326, 272);
            this.btnRepository.Name = "btnRepository";
            this.btnRepository.Size = new System.Drawing.Size(157, 27);
            this.btnRepository.TabIndex = 28;
            this.btnRepository.Text = "Repository";
            this.btnRepository.UseVisualStyleBackColor = true;
            this.btnRepository.Click += new System.EventHandler(this.btnRepository_Click);
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(326, 302);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(157, 21);
            this.btnCommand1.TabIndex = 29;
            this.btnCommand1.Text = "Command 1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(326, 329);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(157, 21);
            this.btnCommand2.TabIndex = 30;
            this.btnCommand2.Text = "Command 2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnIterator1
            // 
            this.btnIterator1.Location = new System.Drawing.Point(32, 379);
            this.btnIterator1.Name = "btnIterator1";
            this.btnIterator1.Size = new System.Drawing.Size(125, 30);
            this.btnIterator1.TabIndex = 31;
            this.btnIterator1.Text = "Iterator 1";
            this.btnIterator1.UseVisualStyleBackColor = true;
            this.btnIterator1.Click += new System.EventHandler(this.btnIterator1_Click);
            // 
            // frmTestPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 494);
            this.Controls.Add(this.btnIterator1);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Controls.Add(this.btnRepository);
            this.Controls.Add(this.btnPolimorfismo2);
            this.Controls.Add(this.btnPrototype);
            this.Controls.Add(this.btnChainOfResponsibility);
            this.Controls.Add(this.btnSegregacionDeInterfaces);
            this.Controls.Add(this.btnLiskov);
            this.Controls.Add(this.btnOpenClose3);
            this.Controls.Add(this.btnOpenClose);
            this.Controls.Add(this.btnSincronizacionThread);
            this.Controls.Add(this.btnThreadingConceptConThreading);
            this.Controls.Add(this.btnThreadConcept);
            this.Controls.Add(this.btnThread1);
            this.Controls.Add(this.btnPolimorfismo1);
            this.Controls.Add(this.btnObserver1);
            this.Controls.Add(this.btnInversionDeDepencias2);
            this.Controls.Add(this.btnInversionDeDependencias1);
            this.Controls.Add(this.btnLoadBalancer);
            this.Controls.Add(this.btnSingleton);
            this.Controls.Add(this.txtVisor);
            this.Controls.Add(this.btnStrategy);
            this.Controls.Add(this.btnStatePatterm);
            this.Controls.Add(this.btnDecorator);
            this.Controls.Add(this.btnFlyWeight);
            this.Controls.Add(this.btnBuilder);
            this.Controls.Add(this.btnAbstractFactory);
            this.Controls.Add(this.btnFactoryPattern);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestPattern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTestPattern";
            this.Load += new System.EventHandler(this.frmTestPattern_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFactoryPattern;
        private System.Windows.Forms.Button btnBuilder;
        private System.Windows.Forms.Button btnAbstractFactory;
        private System.Windows.Forms.Button btnStrategy;
        private System.Windows.Forms.Button btnStatePatterm;
        private System.Windows.Forms.Button btnDecorator;
        private System.Windows.Forms.Button btnFlyWeight;
        private System.Windows.Forms.TextBox txtVisor;
        private System.Windows.Forms.Button btnSingleton;
        private System.Windows.Forms.Button btnLoadBalancer;
        private System.Windows.Forms.Button btnInversionDeDependencias1;
        private System.Windows.Forms.Button btnInversionDeDepencias2;
        private System.Windows.Forms.Button btnObserver1;
        private System.Windows.Forms.Button btnPolimorfismo1;
        private System.Windows.Forms.Button btnThread1;
        private System.Windows.Forms.Button btnThreadConcept;
        private System.Windows.Forms.Button btnThreadingConceptConThreading;
        private System.Windows.Forms.Button btnSincronizacionThread;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Button btnOpenClose3;
        private System.Windows.Forms.Button btnLiskov;
        private System.Windows.Forms.Button btnSegregacionDeInterfaces;
        private System.Windows.Forms.Button btnChainOfResponsibility;
        private System.Windows.Forms.Button btnPrototype;
        private System.Windows.Forms.Button btnPolimorfismo2;
        private System.Windows.Forms.Button btnRepository;
        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnIterator1;
    }
}