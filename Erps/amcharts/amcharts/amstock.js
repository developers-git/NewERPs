(function () {
  var d = window.AmCharts;
  d.AmStockChart = d.Class({
    construct: function (a) {
      this.type = 'stock';
      this.cname = 'AmStockChart';
      d.addChart(this);
      this.version = '3.20.12';
      this.theme = a;
      this.createEvents('buildStarted', 'zoomed', 'rollOverStockEvent', 'rollOutStockEvent', 'clickStockEvent', 'panelRemoved', 'dataUpdated', 'init', 'rendered', 'drawn', 'resized');
      this.colors = '#FF6600 #FCD202 #B0DE09 #0D8ECF #2A0CD0 #CD0D74 #CC0000 #00CC00 #0000CC #DDDDDD #999999 #333333 #990000'.split(' ');
      this.firstDayOfWeek = 1;
      this.glueToTheEnd = !1;
      this.dataSetCounter = - 1;
      this.zoomOutOnDataSetChange = !1;
      this.panels = [
      ];
      this.dataSets = [
      ];
      this.chartCursors = [
      ];
      this.comparedDataSets = [
      ];
      this.classNamePrefix = 'amcharts';
      this.categoryAxesSettings = new d.CategoryAxesSettings(a);
      this.valueAxesSettings = new d.ValueAxesSettings(a);
      this.panelsSettings = new d.PanelsSettings(a);
      this.chartScrollbarSettings = new d.ChartScrollbarSettings(a);
      this.chartCursorSettings = new d.ChartCursorSettings(a);
      this.stockEventsSettings = new d.StockEventsSettings(a);
      this.legendSettings = new d.LegendSettings(a);
      this.balloon = new d.AmBalloon(a);
      this.previousEndDate = new Date(0);
      this.previousStartDate = new Date(0);
      this.dataSetCount = this.graphCount = 0;
      this.chartCreated = !1;
      this.processTimeout = 0;
      this.autoResize = this.extendToFullPeriod = !0;
      d.applyTheme(this, a, this.cname)
    },
    write: function (a) {
      var b = this;
      if (b.listeners) for (var c in b.listeners) {
        var e = b.listeners[c];
        b.addListener(e.event, e.method)
      }
      b.fire({
        type: 'buildStarted',
        chart: b
      });
      b.afterWriteTO && clearTimeout(b.afterWriteTO);
      0 < b.processTimeout ? b.afterWriteTO = setTimeout(function () {
        b.afterWrite.call(b, a)
      }, b.processTimeout)  : b.afterWrite(a)
    },
    afterWrite: function (a) {
      var b = this.theme;
      window.AmCharts_path && (this.path = window.AmCharts_path);
      void 0 === this.path && (this.path = d.getPath());
      void 0 === this.path && (this.path = 'amcharts/');
      this.path = d.normalizeUrl(this.path);
      void 0 === this.pathToImages && (this.pathToImages = this.path + 'images/');
      this.initHC || (d.callInitHandler(this), this.initHC = !0);
      d.applyLang(this.language, this);
      this.chartCursors = [
      ];
      var c = this.exportConfig;
      c && d.AmExport && !this.AmExport && (this.AmExport = new d.AmExport(this, c));
      this.amExport && d.AmExport && (this.AmExport = d.extend(this.amExport, new d.AmExport(this), !0));
      this.AmExport && this.AmExport.init();
      this.chartRendered = !1;
      a = 'object' != typeof a ? document.getElementById(a)  : a;
      this.zoomOutOnDataSetChange && (this.endDate = this.startDate = void 0);
      this.categoryAxesSettings = d.processObject(this.categoryAxesSettings, d.CategoryAxesSettings, b);
      this.valueAxesSettings = d.processObject(this.valueAxesSettings, d.ValueAxesSettings, b);
      this.chartCursorSettings = d.processObject(this.chartCursorSettings, d.ChartCursorSettings, b);
      this.chartScrollbarSettings = d.processObject(this.chartScrollbarSettings, d.ChartScrollbarSettings, b);
      this.legendSettings = d.processObject(this.legendSettings, d.LegendSettings, b);
      this.panelsSettings = d.processObject(this.panelsSettings, d.PanelsSettings, b);
      this.stockEventsSettings = d.processObject(this.stockEventsSettings, d.StockEventsSettings, b);
      this.dataSetSelector && (this.dataSetSelector = d.processObject(this.dataSetSelector, d.DataSetSelector, b));
      this.periodSelector && (this.periodSelector = d.processObject(this.periodSelector, d.PeriodSelector, b));
      a.innerHTML = '';
      this.div = a;
      this.measure();
      this.createLayout();
      this.updateDataSets();
      this.addDataSetSelector();
      this.addPeriodSelector();
      this.addPanels();
      this.updatePanels();
      this.addChartScrollbar();
      this.updateData();
      this.skipDefault || this.setDefaultPeriod();
      this.skipEvents = !1
    },
    setDefaultPeriod: function () {
      var a = this.periodSelector;
      a && (this.animationPlayed = !1, a.setDefaultPeriod())
    },
    validateSize: function () {
      this.measurePanels()
    },
    updateDataSets: function () {
      var a = this.mainDataSet,
      b = this.dataSets,
      c;
      for (c = 0; c < b.length; c++) {
        var e = b[c],
        e = d.processObject(e, d.DataSet);
        b[c] = e;
        e.id || (this.dataSetCount++, e.id = 'ds' + this.dataSetCount);
        void 0 === e.color && (e.color = this.colors.length - 1 > c ? this.colors[c] : d.randomColor())
      }
      !a && d.ifArray(b) && (this.mainDataSet = this.dataSets[0]);
      this.getSelections()
    },
    getLastDate: function (a) {
      var b = d.getDate(a, this.dataDateFormat, 'fff');
      a = this.categoryAxesSettings.minPeriod;
      b = d.changeDate(b, this.categoryAxesSettings.minPeriod, 1, !0).getTime();
      - 1 == a.indexOf('fff') && --b;
      return new Date(b)
    },
    getFirstDate: function (a) {
      a = d.getDate(a, this.dataDateFormat, 'fff');
      return new Date(d.resetDateToMin(a, this.categoryAxesSettings.minPeriod, 1, this.firstDayOfWeek))
    },
    updateData: function () {
      var a = this,
      b = a.mainDataSet;
      if (b) {
        a.parsingData = !1;
        var c = a.categoryAxesSettings;
        - 1 == d.getItemIndex(c.minPeriod, c.groupToPeriods) && c.groupToPeriods.unshift(c.minPeriod);
        var e = b.dataProvider;
        if (d.ifArray(e)) {
          var h = b.categoryField;
          a.firstDate = a.getFirstDate(e[0][h]);
          a.lastDate = a.getLastDate(e[e.length - 1][h]);
          a.periodSelector && a.periodSelector.setRanges(a.firstDate, a.lastDate);
          b.dataParsed || (a.parsingData = !0, 0 < a.processTimeout ? setTimeout(function () {
            a.parseStockData.call(a, b, c.minPeriod, c.groupToPeriods, a.firstDayOfWeek, a.dataDateFormat)
          }, a.processTimeout)  : a.parseStockData(b, c.minPeriod, c.groupToPeriods, a.firstDayOfWeek, a.dataDateFormat));
          this.updateComparingData()
        } else a.firstDate = void 0,
        a.lastDate = void 0;
        a.fixGlue();
        if (!a.parsingData) a.onDataUpdated()
      }
    },
    fixGlue: function () {
      if (this.glueToTheEnd && this.startDate && this.endDate && this.lastDate) {
        this.startDate = new Date(this.startDate.getTime() + (this.lastDate.getTime() - this.endDate.getTime()) + 1);
        var a = d.extractPeriod(this.categoryAxesSettings.minPeriod);
        this.startDate = d.resetDateToMin(this.startDate, a.period, a.count, this.firstDayOfWeek);
        this.endDate = this.lastDate;
        this.updateScrollbar = !0
      }
    },
    isDataParsed: function () {
      if (this.mainDataSet) {
        for (var a = !0, b = 0; b < this.comparedDataSets.length; b++) this.comparedDataSets[b].dataParsed || (a = !1);
        if (this.mainDataSet.dataParsed && a) return !0
      }
      return !1
    },
    onDataUpdated: function () {
      this.isDataParsed() && (this.updatePanelsWithNewData(), this.skipEvents || this.fire({
        type: 'dataUpdated',
        chart: this
      }))
    },
    updateComparingData: function () {
      var a = this.comparedDataSets,
      b = this.categoryAxesSettings,
      c;
      for (c = 0; c < a.length; c++) {
        var e = a[c];
        e.dataParsed || (this.parsingData = !0, 0 < this.processTimeout ? this.delayedParseStockData(c, e)  : this.parseStockData(e, b.minPeriod, b.groupToPeriods, this.firstDayOfWeek, this.dataDateFormat))
      }
    },
    delayedParseStockData: function (a, b) {
      var c = this,
      e = c.categoryAxesSettings;
      setTimeout(function () {
        c.parseStockData.call(c, b, e.minPeriod, e.groupToPeriods, c.firstDayOfWeek, c.dataDateFormat)
      }, c.processTimeout * a)
    },
    parseStockData: function (a, b, c, e, h) {
      var k = this,
      m = {
      },
      g = a.dataProvider,
      p = a.categoryField;
      if (p) {
        var f = d.getItemIndex(b, c),
        n = c.length,
        l,
        w = g.length,
        t,
        y = {
        };
        for (l = f; l < n; l++) t = c[l],
        m[t] = [
        ];
        var r = {
        },
        z = a.fieldMappings,
        A = z.length;
        for (l = 0; l < w; l++) {
          var B = g[l],
          E = d.getDate(B[p], h, b),
          D = E.getTime(),
          q = {
          };
          for (t = 0; t < A; t++) q[z[t].toField] = B[z[t].fromField];
          var C;
          for (C = f; C < n; C++) {
            t = c[C];
            var u = d.extractPeriod(t),
            F = u.period,
            H = u.count,
            v,
            x;
            if (C == f || D >= y[t] || !y[t]) {
              r[t] = {
              };
              r[t].amCategoryIdField = String(d.resetDateToMin(E, F, H, e).getTime());
              var G;
              for (G = 0; G < A; G++) u = z[G].toField,
              v = r[t],
              null !== q[u] && (x = Number(q[u]), v[u + 'Count'] = 0, isNaN(x) || (v[u + 'Open'] = x, v[u + 'Sum'] = x, v[u + 'High'] = x, v[u + 'AbsHigh'] = x, v[u + 'Low'] = x, v[u + 'Close'] = x, v[u + 'Count'] = 1, v[u + 'Average'] = x));
              v.dataContext = B;
              m[t].push(r[t]);
              C > f && (u = d.newDate(E, b), u = d.changeDate(u, F, H, !0), u = d.resetDateToMin(u, F, H, e), y[t] = u.getTime());
              if (C == f) for (var I in B) B.hasOwnProperty(I) && (r[t][I] = B[I]);
              r[t][p] = d.newDate(E, b)
            } else for (F = 0; F < A; F++) u = z[F].toField,
            v = r[t],
            l == w - 1 && (v[p] = d.newDate(E, b)),
            null !== q[u] && (x = Number(q[u]), isNaN(x) || (isNaN(v[u + 'Low']) && (v[u + 'Low'] = x), x < v[u + 'Low'] && (v[u + 'Low'] = x), isNaN(v[u + 'High']) && (v[u + 'High'] = x), x > v[u + 'High'] && (v[u + 'High'] = x), isNaN(v[u + 'AbsHigh']) && (v[u + 'AbsHigh'] = x), Math.abs(x) > v[u + 'AbsHigh'] && (v[u + 'AbsHigh'] = x), v[u + 'Close'] = x, H = d.getDecimals(v[u + 'Sum']), G = d.getDecimals(x), isNaN(v[u + 'Sum']) && (v[u + 'Sum'] = 0), v[u + 'Sum'] += x, v[u + 'Sum'] = d.roundTo(v[u + 'Sum'], Math.max(H, G)), v[u + 'Count']++, v[u + 'Average'] = v[u + 'Sum'] / v[u + 'Count']))
          }
        }
      }
      a.agregatedDataProviders = m;
      d.ifArray(a.stockEvents) ? 0 < k.processTimeout ? setTimeout(function () {
        k.parseEvents.call(k, a, k.panels, k.stockEventsSettings, k.firstDayOfWeek, k, k.dataDateFormat)
      }, k.processTimeout)  : k.parseEvents(a, k.panels, k.stockEventsSettings, k.firstDayOfWeek, k, k.dataDateFormat)  : (a.dataParsed = !0, k.onDataUpdated())
    },
    parseEvents: function (a, b, c, e, h, k) {
      e = a.stockEvents;
      var m = a.agregatedDataProviders,
      g = b.length,
      p,
      f,
      n,
      l,
      w,
      t;
      for (p = 0; p < g; p++) {
        t = b[p];
        w = t.graphs;
        n = w.length;
        for (f = 0; f < n; f++) l = w[f],
        l.customBulletField = 'amCustomBullet' + l.id + '_' + t.id,
        l.bulletConfigField = 'amCustomBulletConfig' + l.id + '_' + t.id,
        l.chart = t;
        for (f = 0; f < e.length; f++) n = e[f],
        l = n.graph,
        d.isString(l) && (l = d.getObjById(w, l)) && (n.graph = l),
        l && (n.panel = l.chart)
      }
      for (var y in m) if (m.hasOwnProperty(y)) for (b = m[y], g = d.extractPeriod(y), p = b.length, f = 0; f < e.length; f++) {
        n = e[f];
        l = n.date instanceof Date;
        k && !l && (n.date = d.stringToDate(n.date, k));
        l = n.date.getTime();
        var r = this.getEventDataItem(l, b, a, 0, p, g);
        r && (l = n.graph, t = n.panel, w = 'amCustomBullet' + l.id + '_' + t.id, t = 'amCustomBulletConfig' + l.id + '_' + t.id, l && (r[t] ? l = r[t] : (l = {
        }, l.eventDispatcher = h, l.eventObjects = [
        ], l.letters = [
        ], l.descriptions = [
        ], l.shapes = [
        ], l.backgroundColors = [
        ], l.backgroundAlphas = [
        ], l.borderColors = [
        ], l.borderAlphas = [
        ], l.colors = [
        ], l.rollOverColors = [
        ], l.showOnAxis = [
        ], l.values = [
        ], l.showAts = [
        ], l.fontSizes = [
        ], l.showBullets = [
        ], r[w] = d.StackedBullet, r[t] = l), l.eventObjects.push(n), l.letters.push(n.text), l.descriptions.push(n.description), n.type ? l.shapes.push(n.type)  : l.shapes.push(c.type), void 0 !== n.backgroundColor ? l.backgroundColors.push(n.backgroundColor)  : l.backgroundColors.push(c.backgroundColor), isNaN(n.backgroundAlpha) ? l.backgroundAlphas.push(c.backgroundAlpha)  : l.backgroundAlphas.push(n.backgroundAlpha), isNaN(n.borderAlpha) ? l.borderAlphas.push(c.borderAlpha)  : l.borderAlphas.push(n.borderAlpha), void 0 !== n.borderColor ? l.borderColors.push(n.borderColor)  : l.borderColors.push(c.borderColor), void 0 !== n.rollOverColor ? l.rollOverColors.push(n.rollOverColor)  : l.rollOverColors.push(c.rollOverColor), void 0 !== n.showAt ? l.showAts.push(n.showAt)  : l.showAts.push(c.showAt), void 0 !== n.fontSize && l.fontSizes.push(n.fontSize), l.colors.push(n.color), l.values.push(n.value), l.showOnAxis.push(n.showOnAxis), l.showBullets.push(n.showBullet), l.date = new Date(n.date)))
      }
      a.dataParsed = !0;
      this.onDataUpdated()
    },
    getEventDataItem: function (a, b, c, e, h, k) {
      var m = k.period,
      g = k.count,
      p = Math.floor(e + (h - e) / 2),
      f = b[p],
      n = f[c.categoryField],
      l = this.dataDateFormat,
      w = n instanceof Date;
      l && !w && (n = d.stringToDate(n, l));
      l = n.getTime();
      'YYYY' == m && (l = d.resetDateToMin(new Date(n), m, g, this.firstDayOfWeek).getTime());
      m = 'fff' == m ? n.getTime() + 1 : d.resetDateToMin(d.changeDate(new Date(n), k.period, k.count), m, g, this.firstDayOfWeek).getTime();
      if (a >= l && a < m) return f;
      if (!(1 >= h - e)) return a < l ? this.getEventDataItem(a, b, c, e, p, k)  : this.getEventDataItem(a, b, c, p, h, k)
    },
    createLayout: function () {
      var a = this.div,
      b,
      c,
      e = this.classNamePrefix,
      d = document.createElement('div');
      d.style.position = 'relative';
      this.containerDiv = d;
      d.className = e + '-stock-div';
      a.appendChild(d);
      if (a = this.periodSelector) b = a.position;
      if (a = this.dataSetSelector) c = a.position;
      if ('left' == b || 'left' == c) a = document.createElement('div'),
      a.className = e + '-left-div',
      a.style.cssFloat = 'left',
      a.style.styleFloat = 'left',
      a.style.width = '0px',
      a.style.position = 'absolute',
      d.appendChild(a),
      this.leftContainer = a;
      if ('right' == b || 'right' == c) b = document.createElement('div'),
      b.className = e + '-right-div',
      b.style.cssFloat = 'right',
      b.style.styleFloat = 'right',
      b.style.width = '0px',
      d.appendChild(b),
      this.rightContainer = b;
      b = document.createElement('div');
      b.className = e + '-center-div';
      d.appendChild(b);
      this.centerContainer = b;
      d = document.createElement('div');
      d.className = e + '-panels-div';
      b.appendChild(d);
      this.panelsContainer = d
    },
    addPanels: function () {
      this.measurePanels(!0);
      for (var a = this.panels, b = 0; b < a.length; b++) {
        var c = a[b],
        c = d.processObject(c, d.StockPanel, this.theme, !0);
        a[b] = c;
        this.addStockPanel(c, b)
      }
      this.panelsAdded = !0
    },
    measurePanels: function (a) {
      this.measure();
      var b = this.chartScrollbarSettings,
      c = this.divRealHeight,
      e = this.divRealWidth;
      if (this.div) {
        var d = this.panelsSettings.panelSpacing;
        b.enabled && (c -= b.height);
        (b = this.periodSelector) && !b.vertical && (b = b.offsetHeight, c -= b + d);
        (b = this.dataSetSelector) && !b.vertical && (b = b.offsetHeight, c -= b + d);
        a || c == this.prevPH && this.prevPW == e || this.fire({
          type: 'resized',
          chart: this
        });
        this.prevPW != e && (this.prevPW = e);
        if (c != this.prevPH) {
          a = this.panels;
          0 < c && (this.panelsContainer.style.height = c + 'px');
          for (var e = 0, k, b = 0; b < a.length; b++) if (k = a[b]) {
            var m = k.percentHeight;
            isNaN(m) && (m = 100 / a.length, k.percentHeight = m);
            e += m
          }
          this.panelsHeight = Math.max(c - d * (a.length - 1), 0);
          for (b = 0; b < a.length; b++) if (k = a[b]) k.percentHeight = k.percentHeight / e * 100,
          k.panelBox && (k.panelBox.style.height = Math.round(k.percentHeight * this.panelsHeight / 100) + 'px');
          this.prevPH = c
        }
      }
    },
    addStockPanel: function (a, b) {
      var c = this.panelsSettings,
      e = document.createElement('div');
      0 < b && !this.panels[b - 1].showCategoryAxis && (e.style.marginTop = c.panelSpacing + 'px');
      a.hideBalloonReal();
      a.panelBox = e;
      a.stockChart = this;
      a.id || (a.id = 'stockPanel' + b);
      e.className = 'amChartsPanel ' + this.classNamePrefix + '-stock-panel-div ' + this.classNamePrefix + '-stock-panel-div-' + a.id;
      a.pathToImages = this.pathToImages;
      a.path = this.path;
      e.style.height = Math.round(a.percentHeight * this.panelsHeight / 100) + 'px';
      e.style.width = '100%';
      this.panelsContainer.appendChild(e);
      0 < c.backgroundAlpha && (e.style.backgroundColor = c.backgroundColor);
      if (e = a.stockLegend) e = d.processObject(e, d.StockLegend, this.theme),
      e.container = void 0,
      e.title = a.title,
      e.marginLeft = c.marginLeft,
      e.marginRight = c.marginRight,
      e.verticalGap = 3,
      e.position = 'top',
      d.copyProperties(this.legendSettings, e),
      a.addLegend(e, e.divId);
      a.zoomOutText = '';
      this.addCursor(a)
    },
    enableCursors: function (a) {
      var b = this.chartCursors,
      c;
      for (c = 0; c < b.length; c++) b[c].enabled = a
    },
    updatePanels: function () {
      var a = this.panels,
      b;
      for (b = 0; b < a.length; b++) this.updatePanel(a[b]);
      this.mainDataSet && this.updateGraphs();
      this.currentPeriod = void 0
    },
    updatePanel: function (a) {
      a.seriesIdField = 'amCategoryIdField';
      a.dataProvider = [
      ];
      a.chartData = [
      ];
      a.graphs = [
      ];
      var b = a.categoryAxis,
      c = this.categoryAxesSettings;
      d.copyProperties(this.panelsSettings, a);
      d.copyProperties(c, b);
      b.parseDates = !0;
      a.addClassNames = this.addClassNames;
      a.classNamePrefix = this.classNamePrefix;
      a.zoomOutOnDataUpdate = !1;
      void 0 !== this.mouseWheelScrollEnabled && (a.mouseWheelScrollEnabled = this.mouseWheelScrollEnabled);
      void 0 !== this.mouseWheelZoomEnabled && (a.mouseWheelZoomEnabled = this.mouseWheelZoomEnabled);
      a.dataDateFormat = this.dataDateFormat;
      a.language = this.language;
      a.showCategoryAxis ? 'top' == b.position ? a.marginTop = c.axisHeight : a.marginBottom = c.axisHeight : (a.categoryAxis.labelsEnabled = !1, a.chartCursor && (a.chartCursor.categoryBalloonEnabled = !1));
      var c = a.valueAxes,
      e = c.length,
      h;
      0 === e && (h = new d.ValueAxis(this.theme), a.addValueAxis(h));
      b = new d.AmBalloon(this.theme);
      d.copyProperties(this.balloon, b);
      a.balloon = b;
      c = a.valueAxes;
      e = c.length;
      for (b = 0; b < e; b++) h = c[b],
      d.copyProperties(this.valueAxesSettings, h);
      a.listenersAdded = !1;
      a.write(a.panelBox)
    },
    zoom: function (a, b) {
      this.zoomChart(a, b)
    },
    zoomOut: function () {
      this.zoomChart(this.firstDate, this.lastDate)
    },
    updatePanelsWithNewData: function () {
      var a = this.mainDataSet,
      b = this.scrollbarChart;
      this.updateGraphs();
      if (a) {
        var c = this.panels;
        this.currentPeriod = void 0;
        var e;
        for (e = 0; e < c.length; e++) {
          var d = c[e];
          d.categoryField = a.categoryField;
          0 === a.dataProvider.length && (d.dataProvider = [
          ]);
          d.scrollbarChart = b
        }
        if (b) {
          c = this.categoryAxesSettings;
          e = c.minPeriod;
          b.categoryField = a.categoryField;
          d = b.dataProvider;
          if (0 < a.dataProvider.length) {
            var k = this.chartScrollbarSettings.usePeriod;
            b.dataProvider = k ? a.agregatedDataProviders[k] : a.agregatedDataProviders[e]
          } else b.dataProvider = [
          ];
          k = b.categoryAxis;
          k.minPeriod = e;
          k.firstDayOfWeek = this.firstDayOfWeek;
          k.equalSpacing = c.equalSpacing;
          k.axisAlpha = 0;
          k.markPeriodChange = c.markPeriodChange;
          b.bbsetr = !0;
          d != b.dataProvider && b.validateData();
          c = this.panelsSettings;
          b.maxSelectedTime = c.maxSelectedTime;
          b.minSelectedTime = c.minSelectedTime
        }
        0 < a.dataProvider.length && (this.fixGlue(), this.zoomChart(this.startDate, this.endDate))
      }
      this.panelDataInvalidated = !1
    },
    addChartScrollbar: function () {
      var a = this.chartScrollbarSettings,
      b = this.scrollbarChart;
      b && (b.clear(), b.destroy());
      if (a.enabled) {
        var c = this.panelsSettings,
        e = this.categoryAxesSettings,
        b = new d.AmSerialChart(this.theme);
        b.svgIcons = c.svgIcons;
        b.language = this.language;
        b.pathToImages = this.pathToImages;
        b.autoMargins = !1;
        this.scrollbarChart = b;
        b.id = 'scrollbarChart';
        b.scrollbarOnly = !0;
        b.zoomOutText = '';
        c.fontFamily && (b.fontFamily = c.fontFamily);
        isNaN(c.fontSize) || (b.fontSize = c.fontSize);
        b.marginLeft = c.marginLeft;
        b.marginRight = c.marginRight;
        b.marginTop = 0;
        b.marginBottom = 0;
        var c = e.dateFormats,
        h = b.categoryAxis;
        h.boldPeriodBeginning = e.boldPeriodBeginning;
        c && (h.dateFormats = e.dateFormats);
        h.labelsEnabled = !1;
        h.parseDates = !0;
        e = a.graph;
        if (d.isString(e)) {
          c = this.panels;
          for (h = 0; h < c.length; h++) {
            var k = d.getObjById(c[h].stockGraphs, a.graph);
            k && (e = k)
          }
          a.graph = e
        }
        var m;
        e && (m = new d.AmGraph(this.theme), m.valueField = e.valueField, m.periodValue = e.periodValue, m.type = e.type, m.connect = e.connect, m.minDistance = a.minDistance, b.addGraph(m));
        e = new d.ChartScrollbar(this.theme);
        b.addChartScrollbar(e);
        d.copyProperties(a, e);
        e.scrollbarHeight = a.height;
        e.graph = m;
        this.listenTo(e, 'zoomed', this.handleScrollbarZoom);
        m = document.createElement('div');
        m.className = this.classNamePrefix + '-scrollbar-chart-div';
        m.style.height = a.height + 'px';
        e = this.periodSelectorContainer;
        c = this.periodSelector;
        h = this.centerContainer;
        'bottom' == a.position ? c ? 'bottom' == c.position ? h.insertBefore(m, e)  : h.appendChild(m)  : h.appendChild(m)  : c ? 'top' == c.position ? h.insertBefore(m, e.nextSibling)  : h.insertBefore(m, h.firstChild)  : h.insertBefore(m, h.firstChild);
        b.write(m)
      }
    },
    handleScrollbarZoom: function (a) {
      if (this.skipScrollbarEvent) this.skipScrollbarEvent = !1;
       else {
        var b = a.endDate,
        c = {
        };
        c.startDate = a.startDate;
        c.endDate = b;
        this.updateScrollbar = !1;
        this.handleZoom(c)
      }
    },
    addPeriodSelector: function () {
      var a = this.periodSelector;
      if (a) {
        var b = this.categoryAxesSettings.minPeriod;
        a.minDuration = d.getPeriodDuration(b);
        a.minPeriod = b;
        a.chart = this;
        var c = this.dataSetSelector,
        e,
        b = this.dssContainer;
        c && (e = c.position);
        var c = this.panelsSettings.panelSpacing,
        h = document.createElement('div');
        this.periodSelectorContainer = h;
        var k = this.leftContainer,
        m = this.rightContainer,
        g = this.centerContainer,
        p = this.panelsContainer,
        f = a.width + 2 * c + 'px';
        switch (a.position) {
          case 'left':
            k.style.width = a.width + 'px';
            k.appendChild(h);
            g.style.paddingLeft = f;
            break;
          case 'right':
            g.style.marginRight = f;
            m.appendChild(h);
            m.style.width = a.width + 'px';
            break;
          case 'top':
            p.style.clear = 'both';
            g.insertBefore(h, p);
            h.style.paddingBottom = c + 'px';
            h.style.overflow = 'hidden';
            break;
          case 'bottom':
            h.style.marginTop = c + 'px',
            'bottom' == e ? g.insertBefore(h, b)  : g.appendChild(h)
        }
        this.listenTo(a, 'changed', this.handlePeriodSelectorZoom);
        a.write(h)
      }
    },
    addDataSetSelector: function () {
      var a = this.dataSetSelector;
      if (a) {
        a.chart = this;
        a.dataProvider = this.dataSets;
        var b = a.position,
        c = this.panelsSettings.panelSpacing,
        e = document.createElement('div');
        this.dssContainer = e;
        var d = this.leftContainer,
        k = this.rightContainer,
        m = this.centerContainer,
        g = this.panelsContainer,
        c = a.width + 2 * c + 'px';
        switch (b) {
          case 'left':
            d.style.width = a.width + 'px';
            d.appendChild(e);
            m.style.paddingLeft = c;
            break;
          case 'right':
            m.style.marginRight = c;
            k.appendChild(e);
            k.style.width = a.width + 'px';
            break;
          case 'top':
            g.style.clear = 'both';
            m.insertBefore(e, g);
            e.style.overflow = 'hidden';
            break;
          case 'bottom':
            m.appendChild(e)
        }
        a.write(e)
      }
    },
    handlePeriodSelectorZoom: function (a) {
      var b = this.scrollbarChart;
      b && (b.updateScrollbar = !0);
      a.predefinedPeriod ? (this.predefinedStart = a.startDate, this.predefinedEnd = a.endDate)  : this.predefinedEnd = this.predefinedStart = null;
      this.zoomOutValueAxes();
      this.zoomChart(a.startDate, a.endDate)
    },
    zoomOutValueAxes: function () {
      var a = this.panels;
      if (this.panelsSettings.zoomOutAxes) for (var b = 0; b < a.length; b++) {
        var c = a[b].valueAxes;
        if (c) for (var e = 0; e < c.length; e++) {
          var d = c[e];
          d.minZoom = NaN;
          d.maxZoom = NaN
        }
      }
    },
    addCursor: function (a) {
      var b = this.chartCursorSettings;
      if (b.enabled) {
        var c = new d.ChartCursor(this.theme);
        d.copyProperties(b, c);
        var e = b.categoryBalloonFunction;
        a.chartCursor && (d.copyProperties(a.chartCursor, c), a.chartCursor.categoryBalloonFunction && (e = a.chartCursor.categoryBalloonFunction));
        c.categoryBalloonFunction = e;
        a.removeChartCursor();
        a.addChartCursor(c);
        'mouse' == b.cursorPosition ? this.listenTo(c, 'moved', this.handleCursorChange)  : this.listenTo(c, 'changed', this.handleCursorChange);
        this.listenTo(c, 'onHideCursor', this.handleCursorChange);
        this.listenTo(c, 'zoomStarted', this.handleCursorChange);
        this.listenTo(c, 'zoomed', this.handleCursorZoom);
        this.chartCursors.push(c)
      }
    },
    handleCursorChange: function (a) {
      a = a.target;
      var b = this.chartCursors,
      c;
      for (c = 0; c < b.length; c++) {
        var e = b[c];
        e != a && e.syncWithCursor(a, this.chartCursorSettings.onePanelOnly)
      }
    },
    handleCursorZoom: function (a) {
      var b = this.scrollbarChart;
      b && (b.updateScrollbar = !0);
      var b = {
      },
      c,
      e;
      if (this.categoryAxesSettings.equalSpacing) {
        e = this.mainDataSet.categoryField;
        var d = this.mainDataSet.agregatedDataProviders[this.currentPeriod];
        c = new Date(d[a.start][e]);
        e = new Date(d[a.end][e])
      } else c = new Date(a.start),
      e = new Date(a.end);
      b.startDate = c;
      b.endDate = e;
      this.handleZoom(b);
      this.handleCursorChange(a)
    },
    handleZoom: function (a) {
      this.zoomChart(a.startDate, a.endDate)
    },
    zoomChart: function (a, b) {
      var c = this;
      a || (a = c.firstDate);
      var e = d.newDate(a),
      h = c.firstDate,
      k = c.lastDate,
      m = c.currentPeriod,
      g = c.categoryAxesSettings,
      p = g.minPeriod,
      f = c.panelsSettings,
      n = c.periodSelector,
      l = c.panels,
      w = c.comparedGraphs,
      t = c.scrollbarChart,
      y = c.firstDayOfWeek;
      if (h && k) {
        a || (a = h);
        b || (b = k);
        if (m) {
          var r = d.extractPeriod(m);
          a.getTime() == b.getTime() && r != p && (b = d.changeDate(b, r.period, r.count), b.setTime(b.getTime() - 1))
        }
        a.getTime() < h.getTime() && (a = h);
        a.getTime() > k.getTime() && (a = k);
        b.getTime() < h.getTime() && (b = h);
        b.getTime() > k.getTime() && (b = k);
        r = d.getItemIndex(p, g.groupToPeriods);
        p = m;
        m = c.choosePeriod(r, a, b);
        c.currentPeriod = m;
        var r = d.extractPeriod(m),
        z = d.getPeriodDuration(r.period, r.count);
        1 > b.getTime() - a.getTime() && (a = new Date(b.getTime() - 1));
        var A = d.newDate(a);
        c.extendToFullPeriod && (A.getTime() - h.getTime() < 0.1 * z && (A = d.resetDateToMin(a, r.period, r.count, y)), k.getTime() - b.getTime() < 0.1 * z && (b = d.resetDateToMin(k, r.period, r.count, y), b = d.changeDate(b, r.period, r.count, !0)));
        for (h = 0; h < l.length; h++) k = l[h],
        k.chartCursor && k.chartCursor.panning && (A = e);
        for (h = 0; h < l.length; h++) {
          k = l[h];
          e = !1;
          if (m != p) {
            for (z = 0; z < w.length; z++) {
              var B = w[z].graph;
              B.dataProvider = B.dataSet.agregatedDataProviders[m]
            }
            z = k.categoryAxis;
            z.firstDayOfWeek = y;
            z.minPeriod = m;
            k.dataProvider = c.mainDataSet.agregatedDataProviders[m];
            if (z = k.chartCursor) z.categoryBalloonDateFormat = c.chartCursorSettings.categoryBalloonDateFormat(r.period),
            k.showCategoryAxis || (z.categoryBalloonEnabled = !1);
            k.startTime = A.getTime();
            k.endTime = b.getTime();
            k.start = NaN;
            k.validateData(!0);
            g.equalSpacing || (e = !0)
          }
          k.chartCursor && k.chartCursor.panning && (e = !0);
          e || (k.startTime = void 0, k.endTime = void 0, k.zoomToDates(A, b));
          0 < f.startDuration && c.animationPlayed && !e ? (k.startDuration = 0, k.animateAgain())  : 0 < f.startDuration && !e && k.animateAgain()
        }
        c.animationPlayed = !0;
        g = d.newDate(b);
        t && c.updateScrollbar && (t.zoomToDates(a, g), c.skipScrollbarEvent = !0, setTimeout(function () {
          c.resetSkip.call(c)
        }, 100));
        c.updateScrollbar = !0;
        c.startDate = a;
        c.endDate = b;
        n && n.zoom(a, b);
        c.skipEvents || a.getTime() == c.previousStartDate.getTime() && b.getTime() == c.previousEndDate.getTime() || (n = {
          type: 'zoomed'
        }, n.startDate = a, n.endDate = b, n.chart = c, n.period = m, c.fire(n), c.previousStartDate = d.newDate(a), c.previousEndDate = d.newDate(b))
      }
      c.eventsHidden && c.showHideEvents(!1);
      c.dispDUpd()
    },
    dispDUpd: function () {
      this.skipEvents || (this.chartCreated || this.fire({
        type: 'init',
        chart: this
      }), this.chartRendered || (this.fire({
        type: 'rendered',
        chart: this
      }), this.chartRendered = !0), this.fire({
        type: 'drawn',
        chart: this
      }));
      this.animationPlayed = this.chartCreated = !0
    },
    resetSkip: function () {
      this.skipScrollbarEvent = !1
    },
    updateGraphs: function () {
      this.getSelections();
      if (0 < this.dataSets.length) {
        var a = this.panels;
        this.comparedGraphs = [
        ];
        var b;
        for (b = 0; b < a.length; b++) {
          var c = a[b],
          e = c.valueAxes,
          h;
          for (h = 0; h < e.length; h++) {
            var k = e[h];
            k.prevLog && (k.logarithmic = k.prevLog);
            k.recalculateToPercents = 'always' == c.recalculateToPercents ? !0 : !1
          }
          e = this.mainDataSet;
          h = this.comparedDataSets;
          k = c.stockGraphs;
          c.graphs = [
          ];
          var m,
          g,
          p;
          for (m = 0; m < k.length; m++) {
            var f = k[m],
            f = d.processObject(f, d.StockGraph, this.theme);
            k[m] = f;
            if (!f.title || f.resetTitleOnDataSetChange) f.title = e.title,
            f.resetTitleOnDataSetChange = !0;
            f.useDataSetColors && (f.lineColor = e.color, f.fillColors = void 0, f.bulletColor = void 0);
            var n = !1,
            l = e.fieldMappings;
            for (g = 0; g < l.length; g++) {
              p = l[g];
              var w = f.valueField;
              w && p.toField == w && (n = !0);
              (w = f.openField) && p.toField == w && (n = !0);
              (w = f.closeField) && p.toField == w && (n = !0);
              (w = f.lowField) && p.toField == w && (n = !0)
            }
            c.graphs.push(f);
            c.processGraphs();
            f.hideFromLegend = n ? !1 : !0;
            w = !1;
            'always' == c.recalculateToPercents && (w = !0);
            var t = c.stockLegend,
            y,
            r,
            z,
            A;
            t && (t = d.processObject(t, d.StockLegend, this.theme), c.stockLegend = t, y = t.valueTextComparing, r = t.valueTextRegular, z = t.periodValueTextComparing, A = t.periodValueTextRegular);
            if (f.comparable) {
              var B = h.length;
              if (f.valueAxis) {
                0 < B && f.valueAxis.logarithmic && 'never' != c.recalculateToPercents && (f.valueAxis.logarithmic = !1, f.valueAxis.prevLog = !0);
                0 < B && 'whenComparing' == c.recalculateToPercents && (f.valueAxis.recalculateToPercents = !0);
                t && f.valueAxis && !0 === f.valueAxis.recalculateToPercents && (w = !0);
                var E;
                for (E = 0; E < B; E++) {
                  var D = h[E],
                  q = f.comparedGraphs[D.id];
                  q || (q = new d.AmGraph(this.theme), q.id = 'comparedGraph_' + f.id + '_' + D.id);
                  f.compareGraphType && (q.type = f.compareGraphType);
                  f.compareGraph && d.copyProperties(f.compareGraph, q);
                  q.periodValue = f.periodValue;
                  q.recalculateValue = f.recalculateValue;
                  q.dataSet = D;
                  q.behindColumns = f.behindColumns;
                  f.comparedGraphs[D.id] = q;
                  q.seriesIdField = 'amCategoryIdField';
                  q.connect = f.connect;
                  q.clustered = f.clustered;
                  q.showBalloon = f.showBalloon;
                  this.passFields(f, q);
                  var C = f.compareField;
                  C || (C = f.valueField);
                  q.customBulletsHidden = !f.showEventsOnComparedGraphs;
                  n = !1;
                  l = D.fieldMappings;
                  for (g = 0; g < l.length; g++) p = l[g],
                  p.toField == C && (n = !0);
                  if (n) {
                    q.valueField = C;
                    q.title = D.title ? D.title : f.title;
                    q.lineColor = D.color;
                    f.compareGraphLineColor && (q.lineColor = f.compareGraphLineColor);
                    g = f.compareGraphLineThickness;
                    isNaN(g) || (q.lineThickness = g);
                    g = f.compareGraphDashLength;
                    isNaN(g) || (q.dashLength = g);
                    g = f.compareGraphLineAlpha;
                    isNaN(g) || (q.lineAlpha = g);
                    g = f.compareGraphCornerRadiusTop;
                    isNaN(g) || (q.cornerRadiusTop = g);
                    g = f.compareGraphCornerRadiusBottom;
                    isNaN(g) || (q.cornerRadiusBottom = g);
                    g = f.compareGraphBalloonColor;
                    isNaN(g) || (q.balloonColor = g);
                    g = f.compareGraphBulletColor;
                    isNaN(g) || (q.bulletColor = g);
                    if (g = f.compareGraphFillColors) q.fillColors = g;
                    if (g = f.compareGraphNegativeFillColors) q.negativeFillColors = g;
                    if (g = f.compareGraphFillAlphas) q.fillAlphas = g;
                    if (g = f.compareGraphNegativeFillAlphas) q.negativeFillAlphas = g;
                    if (g = f.compareGraphBullet) q.bullet = g;
                    if (g = f.compareGraphNumberFormatter) q.numberFormatter = g;
                    g = f.compareGraphPrecision;
                    isNaN(g) || (q.precision = g);
                    if (g = f.compareGraphBalloonText) q.balloonText = g;
                    g = f.compareGraphBulletSize;
                    isNaN(g) || (q.bulletSize = g);
                    g = f.compareGraphBulletAlpha;
                    isNaN(g) || (q.bulletAlpha = g);
                    g = f.compareGraphBulletBorderAlpha;
                    isNaN(g) || (q.bulletBorderAlpha = g);
                    if (g = f.compareGraphBulletBorderColor) q.bulletBorderColor = g;
                    g = f.compareGraphBulletBorderThickness;
                    isNaN(g) || (q.bulletBorderThickness = g);
                    q.visibleInLegend = f.compareGraphVisibleInLegend;
                    q.balloonFunction = f.compareGraphBalloonFunction;
                    q.hideBulletsCount = f.hideBulletsCount;
                    q.valueAxis = f.valueAxis;
                    t && (w && y ? (q.legendValueText = y, q.legendPeriodValueText = z)  : (r && (q.legendValueText = r), q.legendPeriodValueText = A));
                    c.showComparedOnTop ? c.graphs.push(q)  : c.graphs.unshift(q);
                    this.comparedGraphs.push({
                      graph: q,
                      dataSet: D
                    })
                  }
                }
              }
            }
            t && (w && y ? (f.legendValueText = y, f.legendPeriodValueText = z)  : (r && (f.legendValueText = r), f.legendPeriodValueText = A))
          }
        }
      }
    },
    passFields: function (a, b) {
      for (var c = 'lineColor color alpha fillColors description bullet customBullet bulletSize bulletConfig url labelColor dashLength pattern gap className'.split(' '), e = 0; e < c.length; e++) {
        var d = c[e];
        b[d + 'Field'] = a[d + 'Field']
      }
    },
    choosePeriod: function (a, b, c) {
      var e = this.categoryAxesSettings,
      h = e.groupToPeriods,
      k = h[a],
      m = h[a + 1],
      g = d.extractPeriod(k),
      g = d.getPeriodDuration(g.period, g.count),
      p = b.getTime(),
      f = c.getTime(),
      n = e.maxSeries;
      e.alwaysGroup && k == e.minPeriod && (k = 1 < h.length ? h[1] : h[0]);
      return (f - p) / g > n && 0 < n && m ? this.choosePeriod(a + 1, b, c)  : k
    },
    getSelections: function () {
      var a = [
      ],
      b = this.dataSets,
      c;
      for (c = 0; c < b.length; c++) {
        var e = b[c];
        e.compared && a.push(e)
      }
      this.comparedDataSets = a;
      b = this.panels;
      for (c = 0; c < b.length; c++) e = b[c],
      e.hideDrawingIcons && ('never' != e.recalculateToPercents && 0 < a.length ? e.hideDrawingIcons(!0)  : e.drawingIconsEnabled && e.hideDrawingIcons(!1))
    },
    addPanel: function (a) {
      this.panels.push(a);
      this.prevPH = void 0;
      d.removeChart(a);
      d.addChart(a)
    },
    addPanelAt: function (a, b) {
      this.panels.splice(b, 0, a);
      this.prevPH = void 0;
      d.removeChart(a);
      d.addChart(a)
    },
    removePanel: function (a) {
      var b = this.panels;
      this.prevPH = void 0;
      var c;
      for (c = b.length - 1; 0 <= c; c--) b[c] == a && (this.fire({
        type: 'panelRemoved',
        panel: a,
        chart: this
      }), b.splice(c, 1), a.destroy(), a.clear())
    },
    validateData: function (a) {
      var b = this;
      b.validateDataTO && clearTimeout(b.validateDataTO);
      b.validateDataTO = setTimeout(function () {
        b.validateDataReal.call(b, a)
      }, 100)
    },
    validateDataReal: function (a) {
      a || this.resetDataParsed();
      this.updateDataSets();
      this.mainDataSet.compared = !1;
      this.updateData();
      (a = this.dataSetSelector) && a.write(a.div)
    },
    resetDataParsed: function () {
      var a = this.dataSets,
      b;
      for (b = 0; b < a.length; b++) a[b].dataParsed = !1
    },
    validateNow: function (a, b) {
      this.skipDefault = !0;
      this.chartRendered = !1;
      this.prevPH = void 0;
      this.skipEvents = b;
      this.clear(!0);
      this.initTO && clearTimeout(this.initTO);
      a && this.resetDataParsed();
      this.write(this.div)
    },
    hideStockEvents: function () {
      this.showHideEvents(!1);
      this.eventsHidden = !0
    },
    showStockEvents: function () {
      this.showHideEvents(!0);
      this.eventsHidden = !1
    },
    showHideEvents: function (a) {
      var b = this.panels,
      c;
      for (c = 0; c < b.length; c++) {
        var e = b[c].graphs,
        d;
        for (d = 0; d < e.length; d++) {
          var k = e[d];
          !0 === a ? k.showCustomBullets(!0)  : k.hideCustomBullets(!0)
        }
      }
    },
    invalidateSize: function () {
      var a = this;
      clearTimeout(a.validateTO);
      var b = setTimeout(function () {
        a.validateNow()
      }, 5);
      a.validateTO = b
    },
    measure: function () {
      var a = this.div;
      if (a) {
        var b = a.offsetWidth,
        c = a.offsetHeight;
        a.clientHeight && (b = a.clientWidth, c = a.clientHeight);
        this.divRealWidth = b;
        this.divRealHeight = c
      }
    },
    handleResize: function () {
      var a = this,
      b = setTimeout(function () {
        a.validateSizeReal()
      }, 150);
      a.initTO = b
    },
    validateSizeReal: function () {
      this.previousWidth = this.divRealWidth;
      this.previousHeight = this.divRealHeight;
      this.measure();
      if (this.divRealWidth != this.previousWidth || this.divRealHeight != this.previousHeight) 0 < this.divRealWidth && 0 < this.divRealHeight && this.fire({
        type: 'resized',
        chart: this
      }),
      this.divRealHeight != this.previousHeight && this.validateNow()
    },
    clear: function (a) {
      var b = this.panels,
      c;
      if (b) for (c = 0; c < b.length; c++) {
        var e = b[c];
        a || (e.cleanChart(), e.destroy());
        e.clear(a)
      }(b = this.scrollbarChart) && b.clear();
      if (b = this.div) b.innerHTML = '';
      a || (d.removeChart(this), this.div = null, d.deleteObject(this))
    }
  });
  d.StockEvent = d.Class({
    construct: function () {
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.DataSet = d.Class({
    construct: function () {
      this.cname = 'DataSet';
      this.fieldMappings = [
      ];
      this.dataProvider = [
      ];
      this.agregatedDataProviders = [
      ];
      this.stockEvents = [
      ];
      this.compared = !1;
      this.showInCompare = this.showInSelect = !0
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.PeriodSelector = d.Class({
    construct: function (a) {
      this.cname = 'PeriodSelector';
      this.theme = a;
      this.createEvents('changed');
      this.inputFieldsEnabled = !0;
      this.position = 'bottom';
      this.width = 180;
      this.fromText = 'From: ';
      this.toText = 'to: ';
      this.periodsText = 'Zoom: ';
      this.periods = [
      ];
      this.inputFieldWidth = 100;
      this.dateFormat = 'DD-MM-YYYY';
      this.hideOutOfScopePeriods = !0;
      d.applyTheme(this, a, this.cname)
    },
    zoom: function (a, b) {
      var c = this.chart;
      this.inputFieldsEnabled && (this.startDateField.value = d.formatDate(a, this.dateFormat, c), this.endDateField.value = d.formatDate(b, this.dateFormat, c));
      this.markButtonAsSelected()
    },
    write: function (a) {
      var b = this,
      c = b.chart.classNamePrefix;
      a.className = 'amChartsPeriodSelector ' + c + '-period-selector-div';
      var e = b.width,
      h = b.position;
      b.width = void 0;
      b.position = void 0;
      d.applyStyles(a.style, b);
      b.width = e;
      b.position = h;
      b.div = a;
      a.innerHTML = '';
      e = b.theme;
      h = b.position;
      h = 'top' == h || 'bottom' == h ? !1 : !0;
      b.vertical = h;
      var k = 0,
      m = 0;
      if (b.inputFieldsEnabled) {
        var g = document.createElement('div');
        a.appendChild(g);
        var p = document.createTextNode(d.lang.fromText || b.fromText);
        g.appendChild(p);
        h ? d.addBr(g)  : (g.style.styleFloat = 'left', g.style.display = 'inline');
        var f = document.createElement('input');
        f.className = 'amChartsInputField ' + c + '-start-date-input';
        e && d.applyStyles(f.style, e.PeriodInputField);
        f.style.textAlign = 'center';
        f.onblur = function (a) {
          b.handleCalChange(a)
        };
        d.isNN && f.addEventListener('keypress', function (a) {
          b.handleCalendarChange.call(b, a)
        }, !0);
        d.isIE && f.attachEvent('onkeypress', function (a) {
          b.handleCalendarChange.call(b, a)
        });
        g.appendChild(f);
        b.startDateField = f;
        if (h) p = b.width - 6 + 'px',
        d.addBr(g);
         else {
          var p = b.inputFieldWidth + 'px',
          n = document.createTextNode(' ');
          g.appendChild(n)
        }
        f.style.width = p;
        f = document.createTextNode(d.lang.toText || b.toText);
        g.appendChild(f);
        h && d.addBr(g);
        f = document.createElement('input');
        f.className = 'amChartsInputField ' + c + '-end-date-input';
        e && d.applyStyles(f.style, e.PeriodInputField);
        f.style.textAlign = 'center';
        f.onblur = function () {
          b.handleCalChange()
        };
        d.isNN && f.addEventListener('keypress', function (a) {
          b.handleCalendarChange.call(b, a)
        }, !0);
        d.isIE && f.attachEvent('onkeypress', function (a) {
          b.handleCalendarChange.call(b, a)
        });
        g.appendChild(f);
        b.endDateField = f;
        h ? d.addBr(g)  : k = f.offsetHeight + 2;
        p && (f.style.width = p)
      }
      g = b.periods;
      if (d.ifArray(g)) {
        p = document.createElement('div');
        h || (p.style.cssFloat = 'right', p.style.styleFloat = 'right', p.style.display = 'inline');
        a.appendChild(p);
        h && d.addBr(p);
        a = document.createTextNode(d.lang.periodsText || b.periodsText);
        p.appendChild(a);
        b.periodContainer = p;
        var l;
        for (a = 0; a < g.length; a++) f = g[a],
        l = document.createElement('input'),
        l.type = 'button',
        l.value = f.label,
        l.period = f.period,
        l.count = f.count,
        l.periodObj = f,
        l.className = 'amChartsButton ' + c + '-period-input',
        e && d.applyStyles(l.style, e.PeriodButton),
        h && (l.style.width = b.width - 1 + 'px'),
        l.style.boxSizing = 'border-box',
        p.appendChild(l),
        b.addEventListeners(l),
        f.button = l;
        !h && l && (m = l.offsetHeight)
      }
      b.offsetHeight = Math.max(k, m)
    },
    addEventListeners: function (a) {
      var b = this;
      d.isNN && a.addEventListener('click', function (a) {
        b.handlePeriodChange.call(b, a)
      }, !0);
      d.isIE && a.attachEvent('onclick', function (a) {
        b.handlePeriodChange.call(b, a)
      })
    },
    getPeriodDates: function () {
      var a = this.periods,
      b;
      for (b = 0; b < a.length; b++) this.selectPeriodButton(a[b], !0)
    },
    handleCalendarChange: function (a) {
      13 == a.keyCode && this.handleCalChange(a)
    },
    handleCalChange: function (a) {
      var b = this.dateFormat,
      c = d.stringToDate(this.startDateField.value, b),
      b = this.chart.getLastDate(d.stringToDate(this.endDateField.value, b));
      try {
        this.startDateField.blur(),
        this.endDateField.blur()
      } catch (h) {
      }
      if (c && b) {
        var e = {
          type: 'changed'
        };
        e.startDate = c;
        e.endDate = b;
        e.chart = this.chart;
        e.event = a;
        this.fire(e)
      }
    },
    handlePeriodChange: function (a) {
      this.selectPeriodButton((a.srcElement ? a.srcElement : a.target).periodObj, !1, a)
    },
    setRanges: function (a, b) {
      this.firstDate = a;
      this.lastDate = b;
      this.getPeriodDates()
    },
    selectPeriodButton: function (a, b, c) {
      var e = a.button,
      h = e.count,
      k = e.period,
      m = this.chart,
      g,
      p,
      f = this.firstDate,
      n = this.lastDate,
      l,
      w = this.theme;
      g = this.selectFromStart;
      f && n && ('MAX' == k ? (g = f, p = n)  : 'YTD' == k ? (g = new Date, g.setMonth(0, 1), g.setHours(0, 0, 0, 0), 0 === h && g.setDate(g.getDate() - 1), p = this.lastDate)  : 'YYYY' == k || 'MM' == k ? g ? (g = f, p = new Date(f), 'YYYY' == k && (h *= 12), p.setMonth(p.getMonth() + h))  : (g = new Date(n), 'YYYY' == k && (k = 'MM', h *= 12), 'MM' == k && (g = d.resetDateToMin(g, 'DD')), d.changeDate(g, k, h, !1), p = n)  : 'fff' == k ? (d.getPeriodDuration(k, h), l = d.getPeriodDuration(k, h), g ? (g = f, p.setMilliseconds(f.getMilliseconds() - l + 1))  : (g = new Date(n.getTime()), g.setMilliseconds(g.getMilliseconds() - l + 1), p = this.lastDate))  : (l = d.getPeriodDuration(k, h), g ? (g = f, p = new Date(f.getTime() + l - 1))  : (g = new Date(n.getTime() - l + 1), p = n)), a.startTime = g.getTime(), this.hideOutOfScopePeriods && (b && a.startTime < f.getTime() ? e.style.display = 'none' : e.style.display = 'inline'), g.getTime() > n.getTime() && (l = d.getPeriodDuration('DD', 1), g = new Date(n.getTime() - l)), g.getTime() < f.getTime() && (g = f), 'YTD' == k && (a.startTime = g.getTime(), n.getFullYear() < (new Date).getFullYear() && (e.style.display = 'none')), a.endTime = p.getTime(), b || (this.skipMark = !0, this.unselectButtons(), e.className = 'amChartsButtonSelected ' + m.classNamePrefix + '-period-input-selected', w && d.applyStyles(e.style, w.PeriodButtonSelected), a = {
        type: 'changed'
      }, a.startDate = g, a.endDate = p, a.predefinedPeriod = k, a.chart = this.chart, a.count = h, a.event = c, this.fire(a)))
    },
    markButtonAsSelected: function () {
      if (!this.skipMark) {
        var a = this.chart,
        b = this.periods,
        c = a.startDate.getTime(),
        e = a.endDate.getTime(),
        h = this.lastDate.getTime();
        e > h && (e = h);
        h = this.theme;
        this.unselectButtons();
        var k;
        for (k = b.length - 1; 0 <= k; k--) {
          var m = b[k],
          g = m.button;
          m.startTime && m.endTime && c == m.startTime && e == m.endTime && (this.unselectButtons(), g.className = 'amChartsButtonSelected ' + a.classNamePrefix + '-period-input-selected', h && d.applyStyles(g.style, h.PeriodButtonSelected))
        }
      }
      this.skipMark = !1
    },
    unselectButtons: function () {
      var a = this.chart,
      b = this.periods,
      c,
      e = this.theme;
      for (c = b.length - 1; 0 <= c; c--) {
        var h = b[c].button;
        h.className = 'amChartsButton ' + a.classNamePrefix + '-period-input';
        e && d.applyStyles(h.style, e.PeriodButton)
      }
    },
    setDefaultPeriod: function () {
      var a = this.periods,
      b;
      if (this.chart.chartCreated) for (b = 0; b < a.length; b++) {
        var c = a[b];
        c.selected && this.selectPeriodButton(c)
      }
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.StockGraph = d.Class({
    inherits: d.AmGraph,
    construct: function (a) {
      d.StockGraph.base.construct.call(this, a);
      this.cname = 'StockGraph';
      this.useDataSetColors = !0;
      this.periodValue = 'Close';
      this.compareGraphType = 'line';
      this.compareGraphVisibleInLegend = !0;
      this.comparable = this.resetTitleOnDataSetChange = !1;
      this.comparedGraphs = {
      };
      this.showEventsOnComparedGraphs = !1;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.StockPanel = d.Class({
    inherits: d.AmSerialChart,
    construct: function (a) {
      d.StockPanel.base.construct.call(this, a);
      this.cname = 'StockPanel';
      this.theme = a;
      this.showCategoryAxis = this.showComparedOnTop = !0;
      this.recalculateToPercents = 'whenComparing';
      this.panelHeaderPaddingBottom = this.panelHeaderPaddingLeft = this.panelHeaderPaddingRight = this.panelHeaderPaddingTop = 0;
      this.trendLineAlpha = 1;
      this.trendLineColor = '#00CC00';
      this.trendLineColorHover = '#CC0000';
      this.trendLineThickness = 2;
      this.trendLineDashLength = 0;
      this.stockGraphs = [
      ];
      this.drawingIconsEnabled = !1;
      this.iconSize = 38;
      this.autoMargins = this.allowTurningOff = this.eraseAll = this.erasingEnabled = this.drawingEnabled = !1;
      d.applyTheme(this, a, this.cname)
    },
    initChart: function (a) {
      d.StockPanel.base.initChart.call(this, a);
      this.drawingIconsEnabled && this.createDrawIcons();
      (a = this.chartCursor) && this.listenTo(a, 'draw', this.handleDraw)
    },
    addStockGraph: function (a) {
      this.stockGraphs.push(a);
      return a
    },
    handleCursorZoom: function (a) {
      a.start = NaN;
      a.end = NaN;
      d.StockPanel.base.handleCursorZoom.call(this, a)
    },
    removeStockGraph: function (a) {
      var b = this.stockGraphs,
      c;
      for (c = b.length - 1; 0 <= c; c--) b[c] == a && b.splice(c, 1)
    },
    createDrawIcons: function () {
      var a = this,
      b = a.iconSize,
      c = a.container,
      e = a.pathToImages,
      h = a.realWidth - 2 * b - 1 - a.marginRight,
      k = d.rect(c, b, b, '#000', 0.005),
      m = d.rect(c, b, b, '#000', 0.005);
      m.translate(b + 1, 0);
      var g = c.image(e + 'pencilIcon' + a.extension, 0, 0, b, b);
      d.setCN(a, g, 'pencil');
      a.pencilButton = g;
      m.setAttr('cursor', 'pointer');
      k.setAttr('cursor', 'pointer');
      k.mouseup(function () {
        a.handlePencilClick()
      });
      var p = c.image(e + 'pencilIconH' + a.extension, 0, 0, b, b);
      d.setCN(a, p, 'pencil-pushed');
      a.pencilButtonPushed = p;
      a.drawingEnabled || p.hide();
      var f = c.image(e + 'eraserIcon' + a.extension, b + 1, 0, b, b);
      d.setCN(a, f, 'eraser');
      a.eraserButton = f;
      m.mouseup(function () {
        a.handleEraserClick()
      });
      k.touchend && (k.touchend(function () {
        a.handlePencilClick()
      }), m.touchend(function () {
        a.handleEraserClick()
      }));
      b = c.image(e + 'eraserIconH' + a.extension, b + 1, 0, b, b);
      d.setCN(a, b, 'eraser-pushed');
      a.eraserButtonPushed = b;
      a.erasingEnabled || b.hide();
      c = c.set([g,
      p,
      f,
      b,
      k,
      m]);
      d.setCN(a, c, 'drawing-tools');
      c.translate(h, 1);
      this.hideIcons && c.hide()
    },
    handlePencilClick: function () {
      var a = !this.drawingEnabled;
      this.disableDrawing(!a);
      this.erasingEnabled = !1;
      var b = this.eraserButtonPushed;
      b && b.hide();
      b = this.pencilButtonPushed;
      a ? b && b.show()  : (b && b.hide(), this.setMouseCursor('auto'))
    },
    disableDrawing: function (a) {
      this.drawingEnabled = !a;
      var b = this.chartCursor;
      this.stockChart && (this.stockChart.enableCursors(a), b && b.enableDrawing(!a))
    },
    handleEraserClick: function () {
      this.disableDrawing(!0);
      var a = this.pencilButtonPushed;
      a && a.hide();
      a = this.eraserButtonPushed;
      if (this.eraseAll) {
        var a = this.trendLines,
        b;
        for (b = a.length - 1; 0 <= b; b--) {
          var c = a[b];
          c.isProtected || this.removeTrendLine(c)
        }
        this.validateNow()
      } else (this.erasingEnabled = b = !this.erasingEnabled) ? (a && a.show(), this.setTrendColorHover(this.trendLineColorHover), this.setMouseCursor('auto'))  : (a && a.hide(), this.setTrendColorHover())
    },
    setTrendColorHover: function (a) {
      var b = this.trendLines,
      c;
      for (c = b.length - 1; 0 <= c; c--) {
        var e = b[c];
        e.isProtected || (e.rollOverColor = a);
        this.listenTo(e, 'click', this.handleTrendClick)
      }
    },
    handleDraw: function (a) {
      var b = this.drawOnAxis;
      d.isString(b) && (b = this.getValueAxisById(b));
      b || (b = this.valueAxes[0]);
      this.drawOnAxis = b;
      var c = this.categoryAxis,
      e = a.initialX,
      h = a.finalX,
      k = a.initialY;
      a = a.finalY;
      var m = new d.TrendLine(this.theme);
      m.initialDate = c.coordinateToDate(e);
      m.finalDate = c.coordinateToDate(h);
      m.initialValue = b.coordinateToValue(k);
      m.finalValue = b.coordinateToValue(a);
      m.lineAlpha = this.trendLineAlpha;
      m.lineColor = this.trendLineColor;
      m.lineThickness = this.trendLineThickness;
      m.dashLength = this.trendLineDashLength;
      m.valueAxis = b;
      m.categoryAxis = c;
      this.addTrendLine(m);
      this.listenTo(m, 'click', this.handleTrendClick);
      this.validateNow()
    },
    hideDrawingIcons: function (a) {
      (this.hideIcons = a) && this.disableDrawing(a)
    },
    handleTrendClick: function (a) {
      this.erasingEnabled && (a = a.trendLine, this.eraseAll || a.isProtected || this.removeTrendLine(a), this.validateNow())
    },
    handleWheelReal: function (a, b) {
      var c = this.scrollbarChart;
      if (!this.wheelBusy && c) {
        var e = 1;
        this.mouseWheelZoomEnabled ? b || (e = - 1)  : b && (e = - 1);
        var c = c.chartScrollbar,
        d = this.categoryAxis.minDuration();
        0 > a ? (e = this.startTime + e * d, d = this.endTime + 1 * d)  : (e = this.startTime - e * d, d = this.endTime - 1 * d);
        e < this.firstTime && (e = this.firstTime);
        d > this.lastTime && (d = this.lastTime);
        e < d && c.timeZoom(e, d, !0)
      }
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.CategoryAxesSettings = d.Class({
    construct: function (a) {
      this.cname = 'CategoryAxesSettings';
      this.minPeriod = 'DD';
      this.equalSpacing = !1;
      this.axisHeight = 28;
      this.tickLength = this.axisAlpha = 0;
      this.gridCount = 10;
      this.maxSeries = 150;
      this.groupToPeriods = 'ss 10ss 30ss mm 10mm 30mm hh DD WW MM YYYY'.split(' ');
      this.markPeriodChange = this.autoGridCount = !0;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.ChartCursorSettings = d.Class({
    construct: function (a) {
      this.cname = 'ChartCursorSettings';
      this.enabled = !0;
      this.bulletsEnabled = this.valueBalloonsEnabled = !1;
      this.graphBulletSize = 1;
      this.onePanelOnly = !1;
      this.categoryBalloonDateFormats = [
        {
          period: 'YYYY',
          format: 'YYYY'
        },
        {
          period: 'MM',
          format: 'MMM, YYYY'
        },
        {
          period: 'WW',
          format: 'MMM DD, YYYY'
        },
        {
          period: 'DD',
          format: 'MMM DD, YYYY'
        },
        {
          period: 'hh',
          format: 'JJ:NN'
        },
        {
          period: 'mm',
          format: 'JJ:NN'
        },
        {
          period: 'ss',
          format: 'JJ:NN:SS'
        },
        {
          period: 'fff',
          format: 'JJ:NN:SS'
        }
      ];
      d.applyTheme(this, a, this.cname)
    },
    categoryBalloonDateFormat: function (a) {
      var b = this.categoryBalloonDateFormats,
      c,
      e;
      for (e = 0; e < b.length; e++) b[e].period == a && (c = b[e].format);
      return c
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.ChartScrollbarSettings = d.Class({
    construct: function (a) {
      this.cname = 'ChartScrollbarSettings';
      this.height = 40;
      this.enabled = !0;
      this.color = '#FFFFFF';
      this.updateOnReleaseOnly = this.autoGridCount = !0;
      this.hideResizeGrips = !1;
      this.position = 'bottom';
      this.minDistance = 1;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.LegendSettings = d.Class({
    construct: function (a) {
      this.cname = 'LegendSettings';
      this.marginBottom = this.marginTop = 0;
      this.usePositiveNegativeOnPercentsOnly = !0;
      this.positiveValueColor = '#00CC00';
      this.negativeValueColor = '#CC0000';
      this.autoMargins = this.equalWidths = this.textClickEnabled = !1;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.PanelsSettings = d.Class({
    construct: function (a) {
      this.cname = 'PanelsSettings';
      this.marginBottom = this.marginTop = this.marginRight = this.marginLeft = 0;
      this.backgroundColor = '#FFFFFF';
      this.backgroundAlpha = 0;
      this.panelSpacing = 8;
      this.panEventsEnabled = !0;
      this.creditsPosition = 'top-right';
      this.svgIcons = this.zoomOutAxes = !0;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.StockEventsSettings = d.Class({
    construct: function (a) {
      this.cname = 'StockEventsSettings';
      this.type = 'sign';
      this.backgroundAlpha = 1;
      this.backgroundColor = '#DADADA';
      this.borderAlpha = 1;
      this.borderColor = '#888888';
      this.balloonColor = this.rollOverColor = '#CC0000';
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.ValueAxesSettings = d.Class({
    construct: function (a) {
      this.cname = 'ValueAxesSettings';
      this.tickLength = 0;
      this.showFirstLabel = this.autoGridCount = this.inside = !0;
      this.showLastLabel = !1;
      this.axisAlpha = 0;
      d.applyTheme(this, a, this.cname)
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.getItemIndex = function (a, b) {
    var c = - 1,
    e;
    for (e = 0; e < b.length; e++) a == b[e] && (c = e);
    return c
  };
  d.addBr = function (a) {
    a.appendChild(document.createElement('br'))
  };
  d.applyStyles = function (a, b) {
    if (b && a) for (var c in a) {
      var e = c,
      d = b[e];
      if (void 0 !== d) try {
        a[e] = d
      } catch (k) {
      }
    }
  }
}) ();
(function () {
  var d = window.AmCharts;
  d.StockLegend = d.Class({
    inherits: d.AmLegend,
    construct: function (a) {
      d.StockLegend.base.construct.call(this, a);
      this.cname = 'StockLegend';
      this.valueTextComparing = '[[percents.value]]%';
      this.valueTextRegular = '[[value]]';
      d.applyTheme(this, a, this.cname)
    },
    drawLegend: function () {
      var a = this;
      d.StockLegend.base.drawLegend.call(a);
      var b = a.chart;
      if (b.allowTurningOff) {
        var c = a.container,
        e = c.image(b.pathToImages + 'xIcon' + b.extension, b.realWidth - 19, 3, 19, 19),
        b = c.image(b.pathToImages + 'xIconH' +
        b.extension, b.realWidth - 19, 3, 19, 19);
        b.hide();
        a.xButtonHover = b;
        e.mouseup(function () {
          a.handleXClick()
        }).mouseover(function () {
          a.handleXOver()
        });
        b.mouseup(function () {
          a.handleXClick()
        }).mouseout(function () {
          a.handleXOut()
        })
      }
    },
    handleXOver: function () {
      this.xButtonHover.show()
    },
    handleXOut: function () {
      this.xButtonHover.hide()
    },
    handleXClick: function () {
      var a = this.chart,
      b = a.stockChart;
      b.removePanel(a);
      b.validateNow()
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.DataSetSelector = d.Class({
    construct: function (a) {
      this.cname = 'DataSetSelector';
      this.theme = a;
      this.createEvents('dataSetSelected', 'dataSetCompared', 'dataSetUncompared');
      this.position = 'left';
      this.selectText = 'Select:';
      this.comboBoxSelectText = 'Select...';
      this.compareText = 'Compare to:';
      this.width = 180;
      this.dataProvider = [
      ];
      this.listHeight = 150;
      this.listCheckBoxSize = 14;
      this.rollOverBackgroundColor = '#b2e1ff';
      this.selectedBackgroundColor = '#7fceff';
      d.applyTheme(this, a, this.cname)
    },
    write: function (a) {
      var b = this,
      c,
      e = b.theme,
      h = b.chart;
      a.className = 'amChartsDataSetSelector ' + h.classNamePrefix + '-data-set-selector-div';
      var k = b.width;
      c = b.position;
      b.width = void 0;
      b.position = void 0;
      d.applyStyles(a.style, b);
      b.div = a;
      b.width = k;
      b.position = c;
      a.innerHTML = '';
      var k = b.position,
      m;
      m = 'top' == k || 'bottom' == k ? !1 : !0;
      b.vertical = m;
      var g;
      m && (g = b.width + 'px');
      var k = b.dataProvider,
      p,
      f;
      if (1 < b.countDataSets('showInSelect')) {
        c = document.createTextNode(d.lang.selectText || b.selectText);
        a.appendChild(c);
        m && d.addBr(a);
        var n = document.createElement('select');
        g && (n.style.width = g);
        b.selectCB = n;
        e && d.applyStyles(n.style, e.DataSetSelect);
        n.className = h.classNamePrefix + '-data-set-select';
        a.appendChild(n);
        d.isNN && n.addEventListener('change', function (a) {
          b.handleDataSetChange.call(b, a)
        }, !0);
        d.isIE && n.attachEvent('onchange', function (a) {
          b.handleDataSetChange.call(b, a)
        });
        for (c = 0; c < k.length; c++) if (p = k[c], !0 === p.showInSelect) {
          f = document.createElement('option');
          f.className = h.classNamePrefix + '-data-set-select-option';
          f.text = p.title;
          f.value = c;
          p == b.chart.mainDataSet && (f.selected = !0);
          try {
            n.add(f, null)
          } catch (l) {
            n.add(f)
          }
        }
        b.offsetHeight = n.offsetHeight
      }
      if (0 < b.countDataSets('showInCompare') && 1 < k.length) if (m ? (d.addBr(a), d.addBr(a))  : (c = document.createTextNode(' '), a.appendChild(c)), c = document.createTextNode(d.lang.compareText || b.compareText), a.appendChild(c), f = b.listCheckBoxSize, m) {
        d.addBr(a);
        g = document.createElement('div');
        a.appendChild(g);
        g.className = 'amChartsCompareList ' + h.classNamePrefix + '-compare-div';
        e && d.applyStyles(g.style, e.DataSetCompareList);
        g.style.overflow = 'auto';
        g.style.overflowX = 'hidden';
        g.style.width = b.width - 2 + 'px';
        g.style.maxHeight = b.listHeight + 'px';
        for (c = 0; c < k.length; c++) p = k[c],
        !0 === p.showInCompare && p != b.chart.mainDataSet && (e = document.createElement('div'), e.style.padding = '4px', e.style.position = 'relative', e.name = 'amCBContainer', e.className = h.classNamePrefix + '-compare-item-div', e.dataSet = p, e.style.height = f + 'px', p.compared && (e.style.backgroundColor = b.selectedBackgroundColor), g.appendChild(e), m = document.createElement('div'), m.style.width = f + 'px', m.style.height = f + 'px', m.style.position = 'absolute', m.style.backgroundColor = p.color, e.appendChild(m), m = document.createElement('div'), m.style.width = '100%', m.style.position = 'absolute', m.style.left = f + 10 + 'px', e.appendChild(m), p = document.createTextNode(p.title), m.style.whiteSpace = 'nowrap', m.style.cursor = 'default', m.appendChild(p), b.addEventListeners(e));
        d.addBr(a);
        d.addBr(a)
      } else {
        h = document.createElement('select');
        b.compareCB = h;
        g && (h.style.width = g);
        a.appendChild(h);
        d.isNN && h.addEventListener('change', function (a) {
          b.handleCBSelect.call(b, a)
        }, !0);
        d.isIE && h.attachEvent('onchange', function (a) {
          b.handleCBSelect.call(b, a)
        });
        f = document.createElement('option');
        f.text = d.lang.comboBoxSelectText || b.comboBoxSelectText;
        try {
          h.add(f, null)
        } catch (l) {
          h.add(f)
        }
        for (c = 0; c < k.length; c++) if (p = k[c], !0 === p.showInCompare && p != b.chart.mainDataSet) {
          f = document.createElement('option');
          f.text = p.title;
          f.value = c;
          p.compared && (f.selected = !0);
          try {
            h.add(f, null)
          } catch (l) {
            h.add(f)
          }
        }
        b.offsetHeight = h.offsetHeight
      }
    },
    addEventListeners: function (a) {
      var b = this;
      d.isNN && (a.addEventListener('mouseover', function (a) {
        b.handleRollOver.call(b, a)
      }, !0), a.addEventListener('mouseout', function (a) {
        b.handleRollOut.call(b, a)
      }, !0), a.addEventListener('click', function (a) {
        b.handleClick.call(b, a)
      }, !0));
      d.isIE && (a.attachEvent('onmouseout', function (a) {
        b.handleRollOut.call(b, a)
      }), a.attachEvent('onmouseover', function (a) {
        b.handleRollOver.call(b, a)
      }), a.attachEvent('onclick', function (a) {
        b.handleClick.call(b, a)
      }))
    },
    handleDataSetChange: function () {
      var a = this.selectCB,
      a = this.dataProvider[a.options[a.selectedIndex].value],
      b = this.chart;
      b.mainDataSet = a;
      b.zoomOutOnDataSetChange && (b.startDate = void 0, b.endDate = void 0);
      b.validateData(!0);
      this.fire({
        type: 'dataSetSelected',
        dataSet: a,
        chart: this.chart
      })
    },
    handleRollOver: function (a) {
      a = this.getRealDiv(a);
      a.dataSet.compared || (a.style.backgroundColor = this.rollOverBackgroundColor)
    },
    handleRollOut: function (a) {
      a = this.getRealDiv(a);
      a.dataSet.compared || (a.style.removeProperty && a.style.removeProperty('background-color'), a.style.removeAttribute && a.style.removeAttribute('backgroundColor'))
    },
    handleCBSelect: function (a) {
      var b = this.compareCB,
      c = this.dataProvider,
      e,
      d;
      for (e = 0; e < c.length; e++) d = c[e],
      d.compared && (a = {
        type: 'dataSetUncompared',
        dataSet: d
      }),
      d.compared = !1;
      c = b.selectedIndex;
      0 < c && (d = this.dataProvider[b.options[c].value], d.compared || (a = {
        type: 'dataSetCompared',
        dataSet: d
      }), d.compared = !0);
      b = this.chart;
      b.validateData(!0);
      a.chart = b;
      this.fire(a)
    },
    handleClick: function (a) {
      a = this.getRealDiv(a).dataSet;
      !0 === a.compared ? (a.compared = !1, a = {
        type: 'dataSetUncompared',
        dataSet: a
      })  : (a.compared = !0, a = {
        type: 'dataSetCompared',
        dataSet: a
      });
      var b = this.chart;
      b.validateData(!0);
      a.chart = b;
      this.fire(a)
    },
    getRealDiv: function (a) {
      a || (a = window.event);
      a = a.currentTarget ? a.currentTarget : a.srcElement;
      'amCBContainer' == a.parentNode.name && (a = a.parentNode);
      return a
    },
    countDataSets: function (a) {
      var b = this.dataProvider,
      c = 0,
      d;
      for (d = 0; d < b.length; d++) !0 === b[d][a] && c++;
      return c
    }
  })
}) ();
(function () {
  var d = window.AmCharts;
  d.StackedBullet = d.Class({
    construct: function () {
      this.stackDown = !1;
      this.mastHeight = 8;
      this.shapes = [
      ];
      this.backgroundColors = [
      ];
      this.backgroundAlphas = [
      ];
      this.borderAlphas = [
      ];
      this.borderColors = [
      ];
      this.colors = [
      ];
      this.rollOverColors = [
      ];
      this.showOnAxiss = [
      ];
      this.values = [
      ];
      this.showAts = [
      ];
      this.textColor = '#000000';
      this.nextY = 0;
      this.size = 16
    },
    parseConfig: function () {
      var a = this.bulletConfig;
      this.eventObjects = a.eventObjects;
      this.letters = a.letters;
      this.shapes = a.shapes;
      this.backgroundColors = a.backgroundColors;
      this.backgroundAlphas = a.backgroundAlphas;
      this.borderColors = a.borderColors;
      this.borderAlphas = a.borderAlphas;
      this.colors = a.colors;
      this.rollOverColors = a.rollOverColors;
      this.date = a.date;
      this.showOnAxiss = a.showOnAxis;
      this.axisCoordinate = a.minCoord;
      this.showAts = a.showAts;
      this.values = a.values;
      this.fontSizes = a.fontSizes;
      this.showBullets = a.showBullets
    },
    write: function (a) {
      this.parseConfig();
      this.container = a;
      this.bullets = [
      ];
      this.fontSize = this.chart.fontSize;
      if (this.graph) {
        var b = this.graph.fontSize;
        b && (this.fontSize = b)
      }
      b = this.letters.length;
      (this.mastHeight + 2 * (this.fontSize / 2 + 2)) * b > this.availableSpace && (this.stackDown = !0);
      this.set = a.set();
      this.cset = a.set();
      this.set.push(this.cset);
      this.set.doNotScale = !0;
      a = 0;
      var c;
      for (c = 0; c < b; c++) {
        this.shape = this.shapes[c];
        this.backgroundColor = this.backgroundColors[c];
        this.backgroundAlpha = this.backgroundAlphas[c];
        this.borderAlpha = this.borderAlphas[c];
        this.borderColor = this.borderColors[c];
        this.rollOverColor = this.rollOverColors[c];
        this.showOnAxis = this.showOnAxiss[c];
        this.showBullet = this.showBullets[c];
        this.color = this.colors[c];
        this.value = this.values[c];
        this.showAt = this.showAts[c];
        var d = this.fontSizes[c];
        isNaN(d) || (this.fontSize = d);
        this.addLetter(this.letters[c], a, c);
        this.showOnAxis || a++
      }
    },
    addLetter: function (a, b, c) {
      var e = this.container;
      b = e.set();
      var h = - 1,
      k = this.stackDown,
      m = this.graph.valueAxis;
      this.showOnAxis && (this.stackDown = m.reversed ? !0 : !1);
      this.stackDown && (h = 1);
      var g = 0,
      p = 0,
      f = 0,
      n,
      l = this.fontSize,
      w = this.mastHeight,
      t = this.shape,
      y = this.textColor;
      void 0 !== this.color && (y = this.color);
      void 0 === a && (a = '');
      a = d.fixBrakes(a);
      a = d.text(e, a, y, this.chart.fontFamily, this.fontSize);
      a.node.style.pointerEvents = 'none';
      e = a.getBBox();
      this.labelWidth = y = e.width;
      this.labelHeight = e.height;
      var r,
      e = 0;
      switch (t) {
        case 'sign':
          r = this.drawSign(b);
          g = w + 4 + l / 2;
          e = w + l + 4;
          1 == h && (g -= 4);
          break;
        case 'flag':
          r = this.drawFlag(b);
          p = y / 2 + 3;
          g = w + 4 + l / 2;
          e = w + l + 4;
          1 == h && (g -= 4);
          break;
        case 'pin':
          r = this.drawPin(b);
          g = 6 + l / 2;
          e = l + 8;
          break;
        case 'triangleUp':
          r = this.drawTriangleUp(b);
          g = - l - 1;
          e = l + 4;
          h = - 1;
          break;
        case 'triangleDown':
          r = this.drawTriangleDown(b);
          g = l + 1;
          e = l + 4;
          h = - 1;
          break;
        case 'triangleLeft':
          r = this.drawTriangleLeft(b);
          p = l;
          e = l + 4;
          h = - 1;
          break;
        case 'triangleRight':
          r = this.drawTriangleRight(b);
          p = - l;
          h = - 1;
          e = l + 4;
          break;
        case 'arrowUp':
          r = this.drawArrowUp(b);
          a.hide();
          break;
        case 'arrowDown':
          r = this.drawArrowDown(b);
          a.hide();
          e = l + 4;
          break;
        case 'text':
          h = - 1;
          r = this.drawTextBackground(b, a);
          g = this.labelHeight + 3;
          e = l + 10;
          break;
        case 'round':
          r = this.drawCircle(b)
      }
      this.bullets[c] = r;
      this.showOnAxis ? (n = isNaN(this.nextAxisY) ? this.axisCoordinate : this.nextY, f = g * h, this.nextAxisY = n + h * e)  : this.value ? (n = this.value, m.recalculateToPercents && (n = n / m.recBaseValue * 100 - 100), n = m.getCoordinate(n) - this.bulletY, f = g * h)  : this.showAt ? (r = this.graphDataItem.values, m.recalculateToPercents && (r = this.graphDataItem.percents), r && (n = m.getCoordinate(r[this.showAt]) - this.bulletY, f = g * h))  : (n = this.nextY, f = g * h);
      a.translate(p, f);
      b.push(a);
      b.translate(0, n);
      this.addEventListeners(b, c);
      this.nextY = n + h * e;
      this.stackDown = k
    },
    addEventListeners: function (a, b) {
      var c = this;
      a.click(function () {
        c.handleClick(b)
      }).mouseover(function () {
        c.handleMouseOver(b)
      }).touchend(function () {
        c.handleMouseOver(b, !0);
        c.handleClick(b)
      }).mouseout(function () {
        c.handleMouseOut(b)
      })
    },
    drawPin: function (a) {
      var b = - 1;
      this.stackDown && (b = 1);
      var c = this.fontSize + 4;
      return this.drawRealPolygon(a, [
        0,
        c / 2,
        c / 2,
        - c / 2,
        - c / 2,
        0
      ], [
        0,
        b * c / 4,
        b * (c + c / 4),
        b * (c + c / 4),
        b * c / 4,
        0
      ])
    },
    drawSign: function (a) {
      var b = - 1;
      this.stackDown && (b = 1);
      var c = this.mastHeight * b,
      e = this.fontSize / 2 + 2,
      h = d.line(this.container, [
        0,
        0
      ], [
        0,
        c
      ], this.borderColor, this.borderAlpha, 1),
      k = d.circle(this.container, e, this.backgroundColor, this.backgroundAlpha, 1, this.borderColor, this.borderAlpha);
      k.translate(0, c + e * b);
      a.push(h);
      a.push(k);
      this.cset.push(a);
      return k
    },
    drawFlag: function (a) {
      var b = - 1;
      this.stackDown && (b = 1);
      var c = this.fontSize + 4,
      e = this.labelWidth + 6,
      h = this.mastHeight,
      b = 1 == b ? b * h : b * h - c,
      h = d.line(this.container, [
        0,
        0
      ], [
        0,
        b
      ], this.borderColor, this.borderAlpha, 1),
      c = d.polygon(this.container, [
        0,
        e,
        e,
        0
      ], [
        0,
        0,
        c,
        c
      ], this.backgroundColor, this.backgroundAlpha, 1, this.borderColor, this.borderAlpha);
      c.translate(0, b);
      a.push(h);
      a.push(c);
      this.cset.push(a);
      return c
    },
    drawTriangleUp: function (a) {
      var b = this.fontSize +
      7;
      return this.drawRealPolygon(a, [
        0,
        b / 2,
        - b / 2,
        0
      ], [
        0,
        b,
        b,
        0
      ])
    },
    drawArrowUp: function (a) {
      var b = this.size,
      c = b / 2,
      d = b / 4;
      return this.drawRealPolygon(a, [
        0,
        c,
        d,
        d,
        - d,
        - d,
        - c,
        0
      ], [
        0,
        c,
        c,
        b,
        b,
        c,
        c,
        0
      ])
    },
    drawArrowDown: function (a) {
      var b = this.size,
      c = b / 2,
      d = b / 4;
      return this.drawRealPolygon(a, [
        0,
        c,
        d,
        d,
        - d,
        - d,
        - c,
        0
      ], [
        0,
        - c,
        - c,
        - b,
        - b,
        - c,
        - c,
        0
      ])
    },
    drawTriangleDown: function (a) {
      var b = this.fontSize + 7;
      return this.drawRealPolygon(a, [
        0,
        b / 2,
        - b / 2,
        0
      ], [
        0,
        - b,
        - b,
        0
      ])
    },
    drawTriangleLeft: function (a) {
      var b = this.fontSize + 7;
      return this.drawRealPolygon(a, [
        0,
        b,
        b,
        0
      ], [
        0,
        - b / 2,
        b / 2,
        0
      ])
    },
    drawTriangleRight: function (a) {
      var b = this.fontSize + 7;
      return this.drawRealPolygon(a, [
        0,
        - b,
        - b,
        0
      ], [
        0,
        - b / 2,
        b / 2,
        0
      ])
    },
    drawRealPolygon: function (a, b, c) {
      b = d.polygon(this.container, b, c, this.backgroundColor, this.backgroundAlpha, 1, this.borderColor, this.borderAlpha);
      a.push(b);
      this.cset.push(a);
      return b
    },
    drawCircle: function (a) {
      var b = d.circle(this.container, this.fontSize / 2, this.backgroundColor, this.backgroundAlpha, 1, this.borderColor, this.borderAlpha);
      a.push(b);
      this.cset.push(a);
      return b
    },
    drawTextBackground: function (a, b) {
      var c = b.getBBox(),
      d = - c.width / 2 - 5,
      h = c.width / 2 + 5,
      c = - c.height - 12;
      return this.drawRealPolygon(a, [
        d,
        - 5,
        0,
        5,
        h,
        h,
        d,
        d
      ], [
        - 5,
        - 5,
        0,
        - 5,
        - 5,
        c,
        c,
        - 5
      ])
    },
    handleMouseOver: function (a, b) {
      b || this.bullets[a].attr({
        fill: this.rollOverColors[a]
      });
      var c = this.eventObjects[a],
      e = {
        type: 'rollOverStockEvent',
        eventObject: c,
        graph: this.graph,
        date: this.date
      },
      h = this.bulletConfig.eventDispatcher;
      e.chart = h;
      h.fire(e);
      c.url && this.bullets[a].setAttr('cursor', 'pointer');
      e = this.chart;
      e.showBalloon(d.fixNewLines(c.description), h.stockEventsSettings.balloonColor, !0);
      c = e.graphs;
      for (h = 0; h < c.length; h++) c[h].hideBalloon()
    },
    handleClick: function (a) {
      a = this.eventObjects[a];
      var b = {
        type: 'clickStockEvent',
        eventObject: a,
        graph: this.graph,
        date: this.date
      },
      c = this.bulletConfig.eventDispatcher;
      b.chart = c;
      c.fire(b);
      b = a.urlTarget;
      b || (b = c.stockEventsSettings.urlTarget);
      d.getURL(a.url, b)
    },
    handleMouseOut: function (a) {
      this.bullets[a].attr({
        fill: this.backgroundColors[a]
      });
      a = {
        type: 'rollOutStockEvent',
        eventObject: this.eventObjects[a],
        graph: this.graph,
        date: this.date
      };
      var b = this.bulletConfig.eventDispatcher;
      a.chart = b;
      this.chart.hideBalloonReal();
      b.fire(a)
    }
  })
}) ();
