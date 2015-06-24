// Code client pour la validation conditionnel d'un champ
jQuery.validator.addMethod("requiredif", function (value, element, params) {
    if ($(element).val() != '') return true

    var $other = $('#' + params.other);

    var otherVal = ($other.attr('type').toUpperCase() == "CHECKBOX") ?
             ($other.attr("checked") ? "true" : "false") : $other.val();

    return params.comp == 'isequalto' ? (otherVal != params.value)
                      : (otherVal == params.value);
});

jQuery.validator.unobtrusive.adapters.add("requiredif", ["other", "comp", "value"],
  function (options) {
      options.rules['requiredif'] = {
          other: options.params.other,
          comp: options.params.comp,
          value: options.params.value
      };
      options.messages['requiredif'] = options.message;
  }
);

// Override date method validate with format: dd/mm/yyyy on Chrome
$.validator.methods.date = function (value, element) {
    var d = value.split("/");
    return this.optional(element) || !/Invalid|NaN/.test(new Date((/chrom(e|ium)/.test(navigator.userAgent.toLowerCase())) ? d[1] + "/" + d[0] + "/" + d[2] : value));
};