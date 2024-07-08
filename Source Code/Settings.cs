namespace RecipeFinder.Properties
{
    /**
     * \class Settings
     **/
    internal sealed partial class Settings
    {
        /**
         * \fn public Settings()
         **/
        public Settings()
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        /**
         * \fn         private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
         * \param [in] sender
         * \param [in] e
         **/
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            // Add code to handle the SettingChangingEvent event here.
        }

        /**
         * \fn         private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
         * \param [in] sender
         * \param [in] e
         **/
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
