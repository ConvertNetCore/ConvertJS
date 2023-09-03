"use strict";
var KTAppSetRule = function () {
    var RenderForm = () => {
        const filterStatus = document.querySelector('#select_action');
        var renderArea = document.querySelector('#render-action-condition');
        $(filterStatus).on('change', e => {
            let value = e.target.value;
            switch (value) {
                case "turn-on":
                case "turn-off":
                case "send-notification-only":
                    renderArea.innerHTML = '';
                    break;
                case "increase-daily-budget":
                case "decrease-daily-budget":
                case "increase-lifetime-budget":
                case "decrease-ifetime-budget":
                case "increase-bid":
                case "decrease-bid":
                    renderArea.innerHTML =
                        ` <!--begin::Input group-->
                        <div class="row g-9 mb-8">
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Maximum daily budget cap</label>
                                <input type="number" class="form-control form-control-solid" name="maximumDailyBudget" placeholder="Enter Maximum daily budget cap">
                            </div>
                            <!--end::Col-->
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Action frequency</label>
                                <select name="actionfrequency" id="select-action-frequency" class="form-select form-select-solid" data-control="select2" data-hide-search="true">
                                    <option value="%">%</option>
                                    <option value="s/">S/</option>
                                </select>
                            </div>
                            <!--end::Col-->
                        </div>
                        <!--end::Input group-->
                        <!--begin::Input group-->
                        <div class="row g-9 mb-8">
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">PEN</label>
                                <input type="number" class="form-control form-control-solid" name="PEN" placeholder="Enter Value">
                            </div>
                            <!--end::Col-->
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Time Frequency</label>
                                <select name="timeFrequency" id="select-time-frequency" class="form-select form-select-solid" data-control="select2" data-hide-search="true">
                                    <option value="once-hourly">Once hourly</option>
                                    <option value="once-every-12-hours">Once every 12 hours</option>
                                    <option value="once-daily">Once daily</option>
                                    <option value="once-weekly">Once weekly</option>
                                    <option value="every-2-weeks">Every 2 weeks</option>
                                </select>
                            </div>
                            <!--end::Col-->
                        </div>
                        <!--end::Input group-->`;
                    break;
                case "scale-budget-by-target-field":
                case "scale-lifetime-budget":
                case "scale-bid":
                    renderArea.innerHTML =
                        `
                        <!--begin::Input group-->
                        <div class="row g-9 mb-8">
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Target field</label>
                                <select name="scaleTargetField" class="form-select form-select-solid" data-control="select2" data-hide-search="true">
                                    <option value="mobile-app-purchase-roas">Mobile app purchase ROAS</option>
                                    <option value="website-purchase-roas">Website purchase ROAS</option>
                                    <option value="cost-per-mobile-app">Cost per mobile app install</option>
                                    <option value="cost-er-mobile-apppurchase">Cost per mobile app purchase</option>
                                    <option value="cost-per-purchase">Cost per purchase (Meta pixel)</option>
                                    <option value="cost-per-offline-purchase">Cost per offline purchase</option>
                                    <option value="cost-per-result">Cost per result</option>
                                    <option value="cost-per-cpm">CPM</option>
                                    <option value="cost-per-cpa">CPA</option>
                                    <option value="cost-per-cpc">CPC</option>
                                </select>
                            </div>
                            <!--end::Col-->
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Target value for target field</label>
                                <input type="number" class="form-control form-control-solid" name="targetValueOfTargetField" placeholder="Enter Value">
                            </div>
                            <!--end::Col-->
                        </div>
                        <!--end::Input group-->
                        <!--begin::Input group-->
                        <div class="row g-9 mb-8">
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Budget range</label>
                                <div class="row justify-content-center align-items-center">
                                    <div class="col-md-5 fv-row">
                                        <input type="number" class="form-control form-control-solid" name="PENStart" placeholder="Enter Value">
                                    </div>
                                    to
                                    <div class="col-md-5 fv-row">
                                        <input type="number" class="form-control form-control-solid" name="PENFinish" placeholder="Enter Value">
                                    </div>
                                </div>
                            </div>
                            <!--end::Col-->
                            <!--begin::Col-->
                            <div class="col-md-6 fv-row">
                                <label class="required fs-6 fw-semibold mb-2">Time Frequency</label>
                                <select name="timeFrequency" id="select-time-frequency" class="form-select form-select-solid" data-control="select2" data-hide-search="true">
                                    <option value="once-hourly">Once hourly</option>
                                    <option value="once-every-12-hours">Once every 12 hours</option>
                                    <option value="once-daily">Once daily</option>
                                    <option value="once-weekly">Once weekly</option>
                                    <option value="every-2-weeks">Every 2 weeks</option>
                                </select>
                            </div>
                            <!--end::Col-->
                        </div>
                        <!--end::Input group-->`;
                    break;
            }
        });
        const Condition1 = document.querySelector('#select_first_condition');
        var Condition2 = document.querySelector('#select_second_condition');
        $(Condition1).on('change', e => {
            let value = e.target.value;
            switch (value) {
                case 'most-common':
                    Condition2.innerHTML =
                        `<option value="spent">Spent</option>
                                <option value="lifetime-spent">Lifetime Spent</option>
                                <option value="frequency">Frequency</option>
                                <option value="result">Results</option>
                                <option value="cost-per-result">Cost per result</option>
                                <option value="mobile-app-install">Mobile app install</option>
                                <option value="cost-per-mobile-app-install">Cost per Mobile App install</option>
                                <option value="mobile-app-purchase-roas">Mobile app purchase ROAS</option>
                                <option value="website-purchase-roas">Website purchase ROAS</option>`;
                    break;
                case 'settings':
                    Condition2.innerHTML =
                        `<option value="campaign-name">Campaign name</option>
                         <option value="objective">Objective</option>
                         <option value="buying-type">Buying type</option>
                         <option value="spend-cap">Spending cap</option>`;
                    break;
                case 'time':
                    Condition2.innerHTML =
                        `<option value="hours-since-creation">Hour since Creattion</option>
                         <option value="active-time">Active time in seconds</option>
                         <option value="current-time">Current time</option>
                         <option value="created-time">Creation time</option>
                         <option value="time-of-last_edit">Time of last edit</option>
                         <option value="start-time">Starts</option>
                         <option value="stop-time">Ends</option>`;
                    break;
                case 'website-conversions':
                    `
                                <option value="offsite-conversion">All website conversions (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-add-payment-info">Adds of payment info (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-add-to-cart">Adds to cart (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-add-to-wishlist">Adds to wishlist (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-complete-registration">Registrations completed (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-initiate-checkout">Checkouts initiated (Meta pixel)</option>
                                <option value="offsite-onversion-fb-pixel-lead">Leads (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-purchase">Purchases (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-search">Searches (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-view-content">Content views (Meta pixel)</option>
                                <option value="offsite-conversion-fb-pixel-other">Other website conversions (Meta pixel)</option>`;
                    break;
                case 'cost-per-website-conversion':
                    Condition2.innerHTML =
                        `<option value="cost-per-add-payment-info-fb">Cost per add of payment info (Meta pixel)</option>
                         <option value="cost-per-add-to-cart-fb">Cost per add to cart (Meta pixel)</option>
                         <option value="cost-per-add-to-wishlist-fb">Cost per add to wishlist (Meta pixel)</option>
                         <option value="cost-per-complete-registration-fb">Cost per registration completed (Meta pixel)</option>
                         <option value="cost-per-initiate-checkout-fb">Cost per checkout initiated (Meta pixel)</option>
                         <option value="cost-per-lead-fb">Cost per lead (Meta pixel)</option>
                         <option value="cost-per-purchase-fb">Cost per purchase (Meta pixel)</option>
                         <option value="cost-per-search-fb">Cost per search (Meta pixel)</option>
                         <option value="cost-per-view-content-fb">Cost per content view (Meta pixel)</option>`;
                    break;
                case 'mobile-app-events':
                    Condition2.innerHTML =
                        `
                                <option value="app-custom-event">All mobile app events</option>
                                <option value="app-custom-event-fb-mobile-achievement-unlocked">Mobile app achievements unlocked</option>
                                <option value="mobile-app-sessions">Mobile app sessions</option>
                                <option value="app-custom-event-fb-mobile-add-payment-info">Mobile app payment info adds</option>
                                <option value="app-custom-event-fb-mobile-add-to-cart">Mobile app adds to cart</option>
                                <option value="app-custom-event-fb-mobile-add-to-wishlist">Mobile app adds to wishlist</option>
                                <option value="app-custom-event-fb-mobile-complete-registration">Mobile app registrations completed</option>
                                <option value="app-custom-event-fb-mobile-content-view">Mobile app content views</option>
                                <option value="app-custom-event-fb-mobile-initiated-checkout">Mobile app checkouts initiated</option>
                                <option value="app-custom-event-fb-mobile-level-achieved">Mobile app levels completed</option>
                                <option value="app-custom-event-fb-mobile-purchase">Mobile app purchases</option>
                                <option value="app-custom-event-fb-mobile-rate">Mobile app ratings submitted</option>
                                <option value="app-custom-event-fb-mobile-search">Mobile app searches</option>
                                <option value="app-custom-event-fb-mobile-spent-credits">Mobile app credits spent</option>
                                <option value="app-custom-event-fb-mobile-tutorial-completion">Mobile app tutorials completed</option>
                                <option value="app-custom-event-other">Other mobile app actions</option>`;
                    break;
                case 'cost-per-mobile-app-event':
                    Condition2.innerHTML =
                        `
                                <option value="cost-per-mobile-achievement-unlocked">Cost per mobile app achievement unlocked</option>
                                <option value="cost-per-mobile-activate-app">Cost per mobile app session</option>
                                <option value="cost-per-mobile-add-payment-info">Cost per mobile app payment info add</option>
                                <option value="cost-per-mobile-add-to-cart">Cost per mobile app add to cart</option>
                                <option value="cost-per-mobile-add-to-wishlist">Cost per mobile app add to wishlist</option>
                                <option value="cost-per-mobile-complete-registration">Cost per mobile app registration completed</option>
                                <option value="cost-per-mobile-content-view">Cost per mobile app content view</option>
                                <option value="cost-per-mobile-initiated-checkout">Cost per mobile app checkout initiated</option>
                                <option value="cost-per-mobile-level-achieved">Cost per mobile app level completed</option>
                                <option value="cost-per-mobile-purchase">Cost per mobile app purchase</option>
                                <option value="cost-per-mobile-rate">Cost per mobile app rating submitted</option>
                                <option value="cost-per-mobile-search">Cost per mobile app search</option>
                                <option value="cost-per-mobile-spent-credits">Cost per mobile app credit spent</option>
                                <option value="cost-per-mobile-tutorial-completion">Cost per mobile app tutorial completed</option>`;
                    break;
                case 'offline-conversions':
                    Condition2.innerHTML =
                        `       <option value="offline-conversion">All offline conversions</option>
                                <option value="offline-conversion-add-payment-info">Offline adds of payment info</option>
                                <option value="offline-conversion-add-to-cart">Offline adds to cart</option>
                                <option value="offline-conversion-add-to-wishlist">Offline adds to wishlist</option>
                                <option value="offline-conversion-complete-registration">Offline registration completed</option>
                                <option value="offline-conversion-initiate-checkout">Offline checkouts initiated</option>
                                <option value="offline-conversion-lead">Offline leads</option>
                                <option value="offline-conversion-other">Other offline conversions</option>
                                <option value="offline-conversion-purchase">Offline purchases</option>
                                <option value="offline-conversion-search">Offline searches</option>
                                <option value="offline-conversion-view-content">Offline content views</option>`;
                    break;
                case 'cost-per-offline-conversion':
                    Condition2.innerHTML =
                        `       <option value="cost-per-offline-conversion">Cost per offline conversion</option>
                                <option value="cost-per-offline-add-payment-info">Cost per offline add of payment info</option>
                                <option value="cost-per-offline-add-to-cart">Cost per offline add to cart</option>
                                <option value="cost-per-offline-complete-registration">Cost per offline registration completed</option>
                                <option value="cost-per-offline-initiate-checkout">Cost per offline checkout initiated</option>
                                <option value="cost-per-offline-lead">Cost per offline lead</option>
                                <option value="cost-per-offline-other">Cost per other offline conversion</option>
                                <option value="cost-per-offline-purchase">Cost per offline purchase</option>
                                <option value="cost-per-offline-view-content">Cost per offline content view</option>`;
                    break;
                case 'other':
                    Condition2.innerHTML =
                        `       <option value="cpc-link">CPC (Link)</option>
                                <option value="link-click">Link clicks</option>
                                <option value="cpm">CPM</option>
                                <option value="link-ctr">CTR (Link)</option>
                                <option value="lifetime-impressions">Lifetime impressions</option>
                                <option value="impressions">Impressions</option>
                                <option value="reach">Reach</option>
                                <option value="leads">Leads</option>
                                <option value="actions">Actions</option>
                                <option value="clicks">Clicks</option>
                                <option value="cpa">CPA</option>
                                <option value="cpc">CPC</option>
                                <option value="cpp">CPP</option>
                                <option value="ctr">CTR</option>
                                <option value="result-rate">Result rate</option>
                                <option value="cost-per-unique-click">Cost per unique click</option>
                                <option value="unique-clicks">Unique clicks</option>
                                <option value="today-spent">Spent today</option>
                                <option value="yesterday-spent">Yesterday spent</option>
                                <option value="post-engagement">Post engagement</option>
                                <option value="cost-per-post-engagement">Cost per post engagement</option>
                                <option value="second-video-views">3-second video views</option>
                                <option value="cost-per-video-view">Cost per video view</option>
                                <option value="page-likes">Page likes</option>
                                <option value="offsite-engagement">Off-site engagements</option>
                                <option value="post">Posts</option>
                                <option value="post-comment">Post comments</option>
                                <option value="post-reaction">Post reactions</option>
                                <option value="content-views">Content views</option>
                                <option value="clicks-to-play-video">Clicks to play video</option>
                                <option value="question-answers">Question answers</option>
                                <option value="new-messaging-connections">New messaging connections</option>
                                <option value="cost-per-new-messaging-connection">Cost per new messaging connection</option>
                                <option value="messaging-replies">Messaging replies</option>
                                <option value="cost-per-messaging_reply">Cost per messaging reply</option>`;
                    break;
            }
        });
        console.log(1);
        const rangeType = document.querySelector('#select-range-atribute');
        var renderRangeValue = document.querySelector('#render-range-value');
        $(rangeType).on('change', e => {
            let value = e.target.value;
            switch (value) {
                case 'greater-than':
                case 'less-than':
                    renderRangeValue.innerHTML =
                        `   <label class="required fs-6 fw-semibold mb-2">Value</label>
                            <input type="number" class="form-control form-control-solid" name="rangeValue" placeholder="Enter the Range Value">`;
                    break;
                case 'in-range':
                case 'not-in-range':
                    renderRangeValue.innerHTML =
                        `
                                <label class="required fs-6 fw-semibold mb-2">Time Range</label>
                                <div class="row align-items-center">
                                    <div class="col-md-5 fv-row">
                                        <input type="number" class="form-control form-control-solid" name="time-start" placeholder="From">
                                    </div>
                                    <div class="col-md-5 fv-row">
                                        <input type="number" class="form-control form-control-solid" name="time-finish" placeholder="To">
                                    </div>
                                </div>`;
                    break;
            }
        });
    }
    // Public methods 
    return {
        init: function () {
            RenderForm();
        }
    };
}();
// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTAppSetRule.init();
});
