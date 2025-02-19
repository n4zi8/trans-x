using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WA_Send_API.DataModel;

namespace WA_Send_API.Function
{
    public class FunctionScheduler
    {
        private bool _isNewStart = true;
        private bool _isGetdataFIOdone, _isGetStatusPreopdone, _isGetStatusOpendone, _isGetShortdone, _isGetOrderdone, _isGetDBCompare, _isGetDBSysCheck;
        private TimeSpan _timeSpanPreop, _timeSpanOpen, _timeSpanShort, _timeSpanOrder, _timeSpanDBcompare, _timeSpanDBSysCheck;

        private DateTime _prevDate;
        private System.Timers.Timer _timer;
        private FunctionContext _context;     

        public FunctionContext FunctionContext
        { 
            get { return this._context; }
            set { this._context = value; }
        }
            
        public FunctionScheduler(FunctionContext context)
        {
            this._context = context;
            this._timer = new System.Timers.Timer(20000);
            this._timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            this._prevDate = DateTime.Now;
        }
        public void Start()
        {
            this._timer.Start();
            _timeSpanPreop = TimeSpan.Parse("08:45:02");
            _timeSpanOpen = TimeSpan.Parse("09:00:02");
            _timeSpanShort = TimeSpan.Parse("16:10:00");
            _timeSpanOrder = TimeSpan.Parse("04:10:00");
            _timeSpanDBcompare = TimeSpan.Parse("02:00:00");
            _timeSpanDBSysCheck = TimeSpan.Parse("01:00:00");
            this._timer_Elapsed(null, null);

            //this._timer.Start(); //for test only
            //_timeSpanDBcompare  = TimeSpan.Parse("07:05:00");
            //_timeSpanOrder      = TimeSpan.Parse("07:11:00");
            //_timeSpanPreop      = TimeSpan.Parse("09:27:00");
            //_timeSpanOpen       = TimeSpan.Parse("07:14:00");
            //_timeSpanShort      = TimeSpan.Parse("07:16:00");
            //_timeSpanDBSysCheck = TimeSpan.Parse("08:40:00");
            //this._timer_Elapsed(null, null);
        }

        public void Stop()
        {
            this._timer.Stop();
        }
                
        private void
            _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this._context == null)
                return;
            if (this._prevDate < DateTime.Now.Date)
            {
                this._prevDate = DateTime.Now;
                this._isGetdataFIOdone = this._isGetStatusPreopdone = this._isGetStatusOpendone =this._isGetShortdone=this._isGetDBCompare = this._isGetDBSysCheck = this._isNewStart = false; 
            }

            /*
            if (_context.GetHolidayDate() == 0)
            {
                System.Threading.Thread.Sleep(10000);//300000
                Application.Exit();
            }
            */

            TimeSpan now = DateTime.Now.TimeOfDay;
            if (_timeSpanPreop <= now && !this._isGetStatusPreopdone )
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanPreop)
                {

                }
                else
                {
                    if (this._context.GetHolidayDate() == 1)
                    {
                        this._isGetStatusPreopdone = true;
                        //this._context.GetOrderStatusPreop();
                        this._context.GetOrderStatusPreOpOUCH();
                        this._context.GetApiPreop();
                    }
                }
                this._isGetStatusPreopdone = true;    
            }

            if (_timeSpanOpen <= now && !this._isGetStatusOpendone)
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanOpen)
                {

                }
                else
                {
                    if (this._context.GetHolidayDate() == 1)
                    {
                        this._isGetStatusOpendone = true;
                        //this._context.GetOrderStatusOpen();
                        this._context.GetOrderStatusOpenOUCH();
                        this._context.GetApiOpen();
                    }
                }
                this._isGetStatusOpendone = true;
            }
            if (_timeSpanShort <= now && !this._isGetShortdone)
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanShort)
                {

                }
                else
                {
                    if (this._context.GetHolidayDate() == 1)
                    {
                        this._isGetShortdone = true;
                        //this._context.GetClientShort();
                        this._context.GetClientShortOUCH();
                        this._context.GetApiShortOUCH();
                    }

                }
                this._isGetShortdone = true;
            }

            if (_timeSpanOrder <= now && !this._isGetOrderdone)
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanOrder)
                {

                }
                else
                {
                    if (this._context.GetHolidayDate() == 1)
                    {
                        if (this._context.GetHolidayDate() == 1)
                        {
                            this._isGetOrderdone = true;
                            //this._context.GetOrderData();
                            this._context.GetOrderDataOuch();
                            this._context.GetApiOrderCheck();
                        }
                    }
                }
                this._isGetOrderdone = true;
            }

            if (_timeSpanDBSysCheck <= now && !this._isGetDBSysCheck)
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanDBSysCheck)
                {

                }
                else
                {
                    this._isGetDBSysCheck = true;

                    this._context.GetSysDBFO();
                    this._context.GetSysDBLEDGER();
                    this._context.GetSysAodb();
                    this._context.GetSysDBBRIDGE();
                    this._context.GetSysOTDB();
                    this._context.GetSysRTDB();
                    this._context.GetDBSys();
                }
                this._isGetDBSysCheck = true;
            }

            if (_timeSpanDBcompare <= now && !this._isGetDBCompare)
            {
                if (this._isNewStart && this._prevDate.TimeOfDay > _timeSpanDBcompare)
                {

                }
                else
                {
                    if (this._context.GetHolidayDate() == 1)
                    {
                        this._isGetDBCompare = true;
                        //this._context.GetDBCompare();
                        this._context.GetDBS21();
                        this._context.GetDBBridgeData();
                        this._context.GetEarlyData();
                    }
                }
                this._isGetDBCompare = true;
            }
            else
            {
                this._isGetdataFIOdone = true;
                //this._context.GetDBTimestamp();
            }
        }
    }
} 