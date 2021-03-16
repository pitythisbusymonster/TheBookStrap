
# ZAP Scanning Report

Generated on Fri, 12 Mar 2021 19:07:07


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 1 |
| Medium | 1 |
| Low | 6 |
| Informational | 3 |

## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- | 
| Cross Site Scripting (Reflected) | High | 2 | 
| Cross-Domain Misconfiguration | Medium | 1 | 
| Incomplete or No Cache-control and Pragma HTTP Header Set | Low | 74 | 
| Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) | Low | 73 | 
| X-Content-Type-Options Header Missing | Low | 2 | 
| Information Disclosure - Suspicious Comments | Informational | 2 | 
| Loosely Scoped Cookie | Informational | 10 | 
| Timestamp Disclosure - Unix | Informational | 105 | 

## Alert Detail


  
  
  
  
### Cross Site Scripting (Reflected)
##### High (Low)
  
  
  
  
#### Description
<p>Cross-site Scripting (XSS) is an attack technique that involves echoing attacker-supplied code into a user's browser instance. A browser instance can be a standard web browser client, or a browser object embedded in a software product such as the browser within WinAmp, an RSS reader, or an email client. The code itself is usually written in HTML/JavaScript, but may also extend to VBScript, ActiveX, Java, Flash, or any other browser-supported technology.</p><p>When an attacker gets a user's browser to execute his/her code, the code will run within the security context (or zone) of the hosting web site. With this level of privilege, the code has the ability to read, modify and transmit any sensitive data accessible by the browser. A Cross-site Scripted user could have his/her account hijacked (cookie theft), their browser redirected to another location, or possibly shown fraudulent content delivered by the web site they are visiting. Cross-site Scripting attacks essentially compromise the trust relationship between a user and the web site. Applications utilizing browser object instances which load content from the file system may execute code under the local machine zone allowing for system compromise.</p><p></p><p>There are three types of Cross-site Scripting attacks: non-persistent, persistent and DOM-based.</p><p>Non-persistent attacks and DOM-based attacks require a user to either visit a specially crafted link laced with malicious code, or visit a malicious web page containing a web form, which when posted to the vulnerable site, will mount the attack. Using a malicious form will oftentimes take place when the vulnerable resource only accepts HTTP POST requests. In such a case, the form can be submitted automatically, without the victim's knowledge (e.g. by using JavaScript). Upon clicking on the malicious link or submitting the malicious form, the XSS payload will get echoed back and will get interpreted by the user's browser and execute. Another technique to send almost arbitrary requests (GET and POST) is by using an embedded client, such as Adobe Flash.</p><p>Persistent attacks occur when the malicious code is submitted to a web site where it's stored for a period of time. Examples of an attacker's favorite targets often include message board posts, web mail messages, and web chat software. The unsuspecting user is not required to interact with any additional site/link (e.g. an attacker site or a malicious link sent via email), just simply view the web page containing the code.</p>
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D4](https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D4)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
Instances: 2
  
### Solution
<p>Phase: Architecture and Design</p><p>Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.</p><p>Examples of libraries and frameworks that make it easier to generate properly encoded output include Microsoft's Anti-XSS library, the OWASP ESAPI Encoding module, and Apache Wicket.</p><p></p><p>Phases: Implementation; Architecture and Design</p><p>Understand the context in which your data will be used and the encoding that will be expected. This is especially important when transmitting data between different components, or when generating outputs that can contain multiple encodings at the same time, such as web pages or multi-part mail messages. Study all expected communication protocols and data representations to determine the required encoding strategies.</p><p>For any data that will be output to another web page, especially any data that was received from external inputs, use the appropriate encoding on all non-alphanumeric characters.</p><p>Consult the XSS Prevention Cheat Sheet for more details on the types of encoding and escaping that are needed.</p><p></p><p>Phase: Architecture and Design</p><p>For any security checks that are performed on the client side, ensure that these checks are duplicated on the server side, in order to avoid CWE-602. Attackers can bypass the client-side checks by modifying values after the checks have been performed, or by changing the client to remove the client-side checks entirely. Then, these modified values would be submitted to the server.</p><p></p><p>If available, use structured mechanisms that automatically enforce the separation between data and code. These mechanisms may be able to provide the relevant quoting, encoding, and validation automatically, instead of relying on the developer to provide this capability at every point where output is generated.</p><p></p><p>Phase: Implementation</p><p>For every web page that is generated, use and specify a character encoding such as ISO-8859-1 or UTF-8. When an encoding is not specified, the web browser may choose a different encoding by guessing which encoding is actually being used by the web page. This can cause the web browser to treat certain sequences as special, opening up the client to subtle XSS attacks. See CWE-116 for more mitigations related to encoding/escaping.</p><p></p><p>To help mitigate XSS attacks against the user's session cookie, set the session cookie to be HttpOnly. In browsers that support the HttpOnly feature (such as more recent versions of Internet Explorer and Firefox), this attribute can prevent the user's session cookie from being accessible to malicious client-side scripts that use document.cookie. This is not a complete solution, since HttpOnly is not supported by all browsers. More importantly, XMLHTTPRequest and other powerful browser technologies provide read access to HTTP headers, including the Set-Cookie header in which the HttpOnly flag is set.</p><p></p><p>Assume all input is malicious. Use an "accept known good" input validation strategy, i.e., use an allow list of acceptable inputs that strictly conform to specifications. Reject any input that does not strictly conform to specifications, or transform it into something that does. Do not rely exclusively on looking for malicious or malformed inputs (i.e., do not rely on a deny list). However, deny lists can be useful for detecting potential attacks or determining which inputs are so malformed that they should be rejected outright.</p><p></p><p>When performing input validation, consider all potentially relevant properties, including length, type of input, the full range of acceptable values, missing or extra inputs, syntax, consistency across related fields, and conformance to business rules. As an example of business rule logic, "boat" may be syntactically valid because it only contains alphanumeric characters, but it is not valid if you are expecting colors such as "red" or "blue."</p><p></p><p>Ensure that you perform input validation at well-defined interfaces within the application. This will help protect the application even if a component is reused or moved elsewhere.</p>
  
### Other information
<p>Raised with LOW confidence as the Content-Type is not HTML</p>
  
### Reference
* http://projects.webappsec.org/Cross-Site-Scripting
* http://cwe.mitre.org/data/definitions/79.html

  
#### CWE Id : 79
  
#### WASC Id : 8
  
#### Source ID : 1

  
  
  
  
### Cross-Domain Misconfiguration
##### Medium (Medium)
  
  
  
  
#### Description
<p>Web browser data loading may be possible, due to a Cross Origin Resource Sharing (CORS) misconfiguration on the web server</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records)
  
  
  * Method: `GET`
  
  
  * Evidence: `Access-Control-Allow-Origin: *`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that sensitive data is not available in an unauthenticated manner (using IP address white-listing, for instance).</p><p>Configure the "Access-Control-Allow-Origin" HTTP header to a more restrictive set of domains, or remove all CORS headers entirely, to allow the web browser to enforce the Same Origin Policy (SOP) in a more restrictive manner.</p>
  
### Other information
<p>The CORS misconfiguration on the web server permits cross-domain read requests from arbitrary third party domains, using unauthenticated APIs on this domain. Web browser implementations do not permit arbitrary third parties to read the response from authenticated APIs, however. This reduces the risk somewhat. This misconfiguration could be used by an attacker to access data that is available in an unauthenticated manner, but which uses some other form of security, such as IP address white-listing.</p>
  
### Reference
* http://www.hpenterprisesecurity.com/vulncat/en/vulncat/vb/html5_overly_permissive_cors_policy.html

  
#### CWE Id : 264
  
#### WASC Id : 14
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=600`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/normandy-recipes-capabilities/changeset?_expected=1615495692907](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/normandy-recipes-capabilities/changeset?_expected=1615495692907)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites/changeset?_expected=1615385045122&_since=%221611838808382%22](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites/changeset?_expected=1615385045122&_since=%221611838808382%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/gfx?_expected=1606146402211](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/gfx?_expected=1606146402211)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/message-groups/changeset?_expected=1595616291726](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/message-groups/changeset?_expected=1595616291726)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/hijack-blocklists?_expected=1605801189258](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/hijack-blocklists?_expected=1605801189258)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-config?_expected=1613587855073](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-config?_expected=1613587855073)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
Instances: 25
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://localhost:44395/CommunityBoard/CommunityBoard](https://localhost:44395/CommunityBoard/CommunityBoard)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Journal/Index](https://localhost:44395/Journal/Index)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1](https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard/Index](https://localhost:44395/CommunityBoard/Index)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
* URL: [https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D2](https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D2)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Admin](https://localhost:44395/Admin)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/Register](https://localhost:44395/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard/BoardPost](https://localhost:44395/CommunityBoard/BoardPost)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/Register](https://localhost:44395/Account/Register)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Agenda/Index](https://localhost:44395/Agenda/Index)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
* URL: [https://localhost:44395/Account/Login](https://localhost:44395/Account/Login)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1](https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D2](https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D2)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Journal/Entry](https://localhost:44395/Journal/Entry)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard](https://localhost:44395/CommunityBoard)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
* URL: [https://localhost:44395/Agenda/Agenda](https://localhost:44395/Agenda/Agenda)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
* URL: [https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D4](https://localhost:44395/Account/Login?ReturnUrl=%2FCommunityBoard%2FReply%3FpostId%3D4)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44395](https://localhost:44395)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache`
  
  
  
  
Instances: 48
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s)
##### Low (Medium)
  
  
  
  
#### Description
<p>The web/application server is leaking information via one or more "X-Powered-By" HTTP response headers. Access to such information may facilitate attackers identifying other frameworks/components your web application is reliant upon and the vulnerabilities such components may be subject to.</p>
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/robots.txt](https://localhost:44395/robots.txt)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FJournal%2FJournal](https://localhost:44395/Account/LogIn?returnUrl=%2FJournal%2FJournal)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Admin/Delete/bc0874e8-d41e-4bda-a57f-ae2ebf938545](https://localhost:44395/Admin/Delete/bc0874e8-d41e-4bda-a57f-ae2ebf938545)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/Login?ReturnUrl=%2FJournal%2FJournal](https://localhost:44395/Account/Login?ReturnUrl=%2FJournal%2FJournal)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FAgenda%2FDayEntry](https://localhost:44395/Account/LogIn?returnUrl=%2FAgenda%2FDayEntry)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/](https://localhost:44395/)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard/Reply?postId=2](https://localhost:44395/CommunityBoard/Reply?postId=2)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/Login?ReturnUrl=%2FAgenda%2FDayEntry](https://localhost:44395/Account/Login?ReturnUrl=%2FAgenda%2FDayEntry)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D6](https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D6)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/sitemap.xml](https://localhost:44395/sitemap.xml)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0](https://localhost:44395/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard/Reply?postId=1](https://localhost:44395/CommunityBoard/Reply?postId=1)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Home/Privacy](https://localhost:44395/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FAgenda%2FAgenda](https://localhost:44395/Account/LogIn?returnUrl=%2FAgenda%2FAgenda)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1](https://localhost:44395/Account/LogIn?returnUrl=%2FCommunityBoard%2FReply%3FpostId%3D1)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Admin/Add](https://localhost:44395/Admin/Add)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/CommunityBoard/CommunityBoard](https://localhost:44395/CommunityBoard/CommunityBoard)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44395/Journal/Index](https://localhost:44395/Journal/Index)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
Instances: 73
  
### Solution
<p>Ensure that your web server, application server, load balancer, etc. is configured to suppress "X-Powered-By" headers.</p>
  
### Reference
* http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx
* http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-04-12-15-03-53.chain](https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-04-12-15-03-53.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Low)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://localhost:44395/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44395/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://localhost:44395/lib/jquery/dist/jquery.min.js](https://localhost:44395/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `username`
  
  
  
  
Instances: 2
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bFROM\b and was detected in the element starting with: "!function(t,e){"object"==typeof exports&&"undefined"!=typeof module?e(exports,require("jquery")):"function"==typeof define&&defi", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Loosely Scoped Cookie
##### Informational (Low)
  
  
  
  
#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44395/Account/Register](https://localhost:44395/Account/Register)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44395/Account/Register](https://localhost:44395/Account/Register)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44395/Account/Login](https://localhost:44395/Account/Login)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44395/Admin/Delete/28b7760f-9267-4f87-8c04-f082bbc1317c](https://localhost:44395/Admin/Delete/28b7760f-9267-4f87-8c04-f082bbc1317c)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44395/Account/Register](https://localhost:44395/Account/Register)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44395/Account/LogIn](https://localhost:44395/Account/LogIn)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44395/Admin/Delete/bc0874e8-d41e-4bda-a57f-ae2ebf938545](https://localhost:44395/Admin/Delete/bc0874e8-d41e-4bda-a57f-ae2ebf938545)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44395/Account/LogOut](https://localhost:44395/Account/LogOut)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44395/Account/Login](https://localhost:44395/Account/Login)
  
  
  * Method: `GET`
  
  
  
  
Instances: 10
  
### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>
  
### Other information
<p>The origin domain used for comparison was: </p><p>localhost</p><p>.AspNetCore.Identity.Application=CfDJ8J25h_GVVAlAudqFyu1vM_PN8r2Rcx5eheq3G6fqB-uOQRNFdTzWfXfbp0wWwaRYVdDSxKMeoEr-921kKnOszKNDYK4OsPerZp9eNIbsOPrqDKY7blcDl9O1p36Aq-mp7jPqXKS5l9FBZkBiGmxyZlf4oJIHv4tvds6FE_dtneXJfSOzak9WAJxNU3mui_mjvY-KXX5nIgJVAd838XKf96QpBTuw-ORmMcoVki6rdZOmnMKFDrFwufY3aNPqYfCMuOgB1TKYU2aSfQrbFKXv7KTyQHrkJK8STzhpRVu2A6ULSIguzXiliJw71WW5ImLPmbExn6PVDH780qEVkoU8HvTvzLsCC3IcqJpenQ4az2hVK3LVb3ld_NuMZaQfAuYSbJJdQB8ARRvJeQZvPg6L7NR_3bHUZYG2Cwvi0nGG_kvT-5Mc622azS8NAJG6vPgcUZCNTdHYKVWlhDUpOnNdsW7WoDrPpV6JE4bljh_lM6gM_1JjtNX_SZ-fBXDTqT6LayGMMeEJmCbG4lvKm8SyJeE0l4ACKFrVUvFRRXO8Q4DkdH5XAS-KcGvT5vXDOqiSVQjSIPf8ZSUgK6a5t5K92nyyb33DOdWCU0pUZ8YEpgtq</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22)
  
  
  * Method: `GET`
  
  
  * Evidence: `211684099`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `86591957`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `26183992`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `10604307`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `16472873`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `22437749`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `20580060`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `40767652`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `11657763`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `93338602`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `29020808`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `164611595`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `29396116`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `15453048`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `161749950`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22)
  
  
  * Method: `GET`
  
  
  * Evidence: `639132644`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615595877745&_since=%221614991099385%22)
  
  
  * Method: `GET`
  
  
  * Evidence: `777728916`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `40960499`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `26372781`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615479186940)
  
  
  * Method: `GET`
  
  
  * Evidence: `12218087`
  
  
  
  
Instances: 105
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>211684099, which evaluates to: 1976-09-15 18:08:19</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3
